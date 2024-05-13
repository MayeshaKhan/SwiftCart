using BLL.DTOs;
using BLL.Services;
using SwiftCart.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwiftCart.Controllers
{
    [CustomAuthorizationFilter]
    [Authorize(Roles = "Agent")]
    public class SellerController : ApiController
    {
        [HttpPost]
        [Route("api/seller/create")]
        public HttpResponseMessage Create(SellerDTO b)
        {
            SellerService.Create(b);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/seller/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = SellerService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/seller/all")]
        public HttpResponseMessage Get()
        {
            var data = SellerService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPut]
        [Route("api/seller/update")]
        public HttpResponseMessage Update(SellerDTO b)
        {
            SellerService.Update(b);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/seller/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            SellerService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
