using BLL.Services;
using SwiftCart.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        [Route("hi")]
        public HttpResponseMessage Index()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
