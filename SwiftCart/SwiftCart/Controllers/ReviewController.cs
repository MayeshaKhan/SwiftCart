using BLL.DTOs;
using BLL.Services;
using SwiftCart.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SwiftCart.Controllers
{
    [CustomAuthorizationFilter]
    [RoutePrefix("api/review")]
    public class ReviewController : ApiController
    {
        
        [Authorize(Roles = "Customer")]
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(ReviewDTO obj)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var customerId = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                if(ReviewService.CreateReview(obj, customerId))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Review created");
                }
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Review not created");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Authorize(Roles = "Customer")]
        [Route("myreview")]
        [HttpGet]
        public HttpResponseMessage GetMyReview()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var customerId = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                var reviewList = ReviewService.GetMyReview(customerId);
                return Request.CreateResponse(HttpStatusCode.OK, reviewList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Authorize(Roles = "Customer")]
        [Route("edit")]
        [HttpPut]
        public HttpResponseMessage Edit(ReviewDTO obj)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var customerId = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                if(ReviewService.EditReview(obj, customerId))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Review Edited");
                }
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Review not Edited");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Authorize(Roles = "Customer")]
        [Route("delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var customerId = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                if(ReviewService.DeleteReview(id, customerId))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Review Deleted");
                }
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Review not deleted");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("get/{id}")]
        [HttpGet]
        public HttpResponseMessage GetReview(int id)
        {
            try
            {
                var reviewObj = ReviewService.GetReview(id);
                if(reviewObj != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, reviewObj);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Review not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("product/{id}")]
        [HttpGet]
        public HttpResponseMessage GetProductReview(int id)
        {
            try
            {
                var reviewList = ReviewService.GetProductReview(id);
                return Request.CreateResponse(HttpStatusCode.OK, reviewList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
