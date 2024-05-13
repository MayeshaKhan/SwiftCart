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
        [Route("api/customer/registration")]
        public HttpResponseMessage Registration(CustomerDTO a)
        {
            
                
                var data = CustomerService.Registration(a);
                
                
             return Request.CreateResponse(HttpStatusCode.OK, new { message = "Registraion is successful" });
                
                

        }
    }
}
