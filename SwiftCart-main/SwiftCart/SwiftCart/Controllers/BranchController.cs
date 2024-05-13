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
    public class BranchController : ApiController
    {   
        [HttpPost]
        [Route("api/branch/create")]
        public HttpResponseMessage Create(BranchDTO b)
    {
        BranchService.Create(b);
        return Request.CreateResponse(HttpStatusCode.OK);

    }
    [HttpGet]
    [Route("api/branch/{id}")]
    public HttpResponseMessage Get(int id)
    {
        var data = BranchService.Get(id);
        return Request.CreateResponse(HttpStatusCode.OK, data);
    }
    [HttpGet]
    [Route("api/branch/all")]
    public HttpResponseMessage Get()
    {
        var data = BranchService.Get();
        return Request.CreateResponse(HttpStatusCode.OK, data);
    }
    [HttpPut]
    [Route("api/branch/update")]
    public HttpResponseMessage Update( BranchDTO b)
    {

            BranchService.Update(b);


        return Request.CreateResponse(HttpStatusCode.OK);
    }

    [HttpDelete]
    [Route("api/branch/delete/{id}")]
    public HttpResponseMessage Delete(int id)
    {
        BranchService.Delete(id);

        return Request.CreateResponse(HttpStatusCode.OK);
    }

}
}
