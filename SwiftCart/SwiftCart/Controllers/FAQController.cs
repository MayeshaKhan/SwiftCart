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
   
    public class FAQController : ApiController
    {

        [HttpGet]
        [Route("api/faq/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = FAQService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/faq/all")]
        public HttpResponseMessage Get()
        {
            var data = FAQService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [CustomAuthorizationFilter]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/faq/create")]
        public HttpResponseMessage Create(FaqDTO a)
        {
            FAQService.Create(a);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [CustomAuthorizationFilter]
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        [Route("api/faq/update")]
        public HttpResponseMessage Update(FaqDTO a)
        {
            FAQService.Update(a);


            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [CustomAuthorizationFilter]
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("api/faq/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            FAQService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
