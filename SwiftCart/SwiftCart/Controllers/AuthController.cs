using BLL.DTOs;
using BLL.Services;
using SwiftCart.Auth;
using SwiftCart.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SwiftCart.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(LoginDTO loginObj)
        {
            try
            {
                var tokenObj = AuthService.Login(loginObj.username, loginObj.password);
                if (tokenObj == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Credential");
                }
                return Request.CreateResponse(HttpStatusCode.OK, tokenObj);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [CustomAuthorizationFilter]
        [HttpGet]
        [Route("profile")]
        public HttpResponseMessage GetProfile()
        {
            var identity = (ClaimsIdentity)User.Identity;
            //Getting the ID value
            var ID = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
            //Getting the UserRole value
            var Role = identity.Claims.FirstOrDefault(c => c.Type == "UserRole").Value;
            var profileData = AuthService.GetProfile(ID, Role);
            if(profileData == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Profile Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, profileData);
        }

        [HttpPost]
        [Route("logout")]
        public HttpResponseMessage Logout(TokenDTO t)
        {
            try
            {
                var tokenObj = AuthService.Logout(t.TokenString );
                if (tokenObj == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Credential");
                }
                return Request.CreateResponse(HttpStatusCode.OK, tokenObj);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
