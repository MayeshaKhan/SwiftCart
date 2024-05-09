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
        [Route("api/customer/create")]
        public HttpResponseMessage Create(CustomerDTO a)
        {
            CustomerService.Create(a);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/customer/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = CustomerService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/customer/all")]
        public HttpResponseMessage Get()
        {
            var data = CustomerService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPut]
        [Route("api/customer/update")]
        public HttpResponseMessage Update(CustomerDTO a)
        {
            CustomerService.Update(a);


            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/customer/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            CustomerService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
