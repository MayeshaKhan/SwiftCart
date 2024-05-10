using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SwiftCart.Auth
{
    public class CustomAuthorizationFilter: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                        System.Net.HttpStatusCode.Unauthorized,
                        new { Message = "No token!" }
                    );
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.ToString();
                var tokenObj = AuthService.ValidateToken(authenticationToken);
                if (tokenObj == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(
                            System.Net.HttpStatusCode.Unauthorized,
                            new { Message = "Invalid Token" }
                        );
                }
                else if (tokenObj.ExpireTime < DateTime.Now)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(
                            System.Net.HttpStatusCode.Unauthorized,
                            new { Message = "Token Expired" }
                        );
                }
                // token is valid
                else
                {
                    var identity = new GenericIdentity(tokenObj.UserId.ToString());
                    identity.AddClaim(new Claim("ID", Convert.ToString(tokenObj.UserId)));
                    identity.AddClaim(new Claim("UserRole", Convert.ToString(tokenObj.UserRole)));
                    var roles = new string[] { tokenObj.UserRole };
                    var principal = new GenericPrincipal(identity, roles);
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                
            }
            
            base.OnAuthorization(actionContext);
        }
    }
}