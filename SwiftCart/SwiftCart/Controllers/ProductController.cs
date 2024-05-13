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
    [Authorize(Roles = "Agent, Seller")]

    public class ProductController : ApiController
    {
            [HttpPost]
            [Route("api/product/create")]
            public HttpResponseMessage Create(ProductDTO a)
            {
                ProductService.Create(a);
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            [HttpGet]
            [Route("api/product/{id}")]
            public HttpResponseMessage Get(int id)
            {
                var data = ProductService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            [HttpGet]
            [Route("api/product/all")]
            public HttpResponseMessage Get()
            {
                var data = ProductService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            [HttpPut]
            [Route("api/product/update")]
            public HttpResponseMessage Update(ProductDTO a)
            {
                ProductService.Update(a);


                return Request.CreateResponse(HttpStatusCode.OK);
            }

            [HttpDelete]
            [Route("api/product/delete/{id}")]
            public HttpResponseMessage Delete(int id)
            {
                ProductService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK);
            }

        }
    }
