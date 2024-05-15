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
using System.Security.Principal;
using System.Web.Http;
using System.Web.UI.WebControls;

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

        [CustomAuthorizationFilter]
        [HttpPost]
        [Route("logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var TokenString = identity.Claims.FirstOrDefault(c => c.Type == "TokenString").Value;
                if (AuthService.Logout(TokenString))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, "Logout Successful");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Logout Unsuccessful");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [CustomAuthorizationFilter]
        [HttpPut]
        [Route("profile/update")]
        public HttpResponseMessage UpdateProfile(updateProfileDTO obj)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var ID = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                //Getting the UserRole value
                var Role = identity.Claims.FirstOrDefault(c => c.Type == "UserRole").Value;
                if (AuthService.UpdateProfile(ID, Role, obj))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, "Profile Update Successful");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Profile Update Unsuccessful");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [CustomAuthorizationFilter]
        [HttpPut]
        [Route("changepassword")]
        public HttpResponseMessage ChangePassword(ChangePasswordDTO obj)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var ID = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                //Getting the UserRole value
                var Role = identity.Claims.FirstOrDefault(c => c.Type == "UserRole").Value;
                if (AuthService.ChangePassword(ID, Role, obj))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, "Password Change Successful");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Password Change Unsuccessful");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
