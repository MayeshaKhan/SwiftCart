using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwiftCart.Controllers
{

    public class CustomerController : ApiController
    {
        [HttpPost]
        [Route("api/customer/signup")]
        public HttpResponseMessage SignUp(CustomerDTO newCustomer)
        {
            try
            {
                CustomerService.SignUp(newCustomer);
                return Request.CreateResponse(HttpStatusCode.OK, "Signup successful.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                bool isAuthenticated = AuthService.Authenticate(login.Username, login.Password);
                if (isAuthenticated)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Login successful.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
