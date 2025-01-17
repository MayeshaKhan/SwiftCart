﻿using BLL.DTOs;
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
    [Authorize(Roles = "Agent,Seller")]
    public class CategoryController : ApiController
    {
        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage Create(CategoryDTO a)
        {
            CategoryService.Create(a);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = CategoryService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage Get()
        {
            var data = CategoryService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPut]
        [Route("api/category/update")]
        public HttpResponseMessage Update(CategoryDTO a)
        {
            CategoryService.Update(a);


            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            CategoryService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
