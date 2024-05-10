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
    [Authorize(Roles ="Admin")]
    public class AgentController : ApiController
    {
        [HttpPost]
        [Route("api/agent/create")]
        public HttpResponseMessage Create(AgentDTO a)
        {
            AgentService.Create(a);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/agent/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = AgentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/agent/all")]
        public HttpResponseMessage Get()
        {
            var data = AgentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPut]
        [Route("api/agent/update")]
        public HttpResponseMessage Update(AgentDTO a)
        {
            AgentService.Update(a);
           
                
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/agent/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            AgentService.Delete(id);
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }


}

