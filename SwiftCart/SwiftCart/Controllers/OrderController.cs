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
    [Authorize(Roles = "Customer")]
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        [Route("place")]
        [HttpPost]
        public HttpResponseMessage PlaceOrder(PlaceOrderDTO obj)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var customerId = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                var message = PlaceOrderService.PlaceOrder(customerId, obj);
                if(message != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Order failed");
                }
            }
            catch(Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("payment/{id}")]
        [HttpPut]
        public HttpResponseMessage PaymentOrder(int id)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var customerId = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                var orderObj = PlaceOrderService.PaymentOrder(customerId, id);
                if (orderObj != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orderObj);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Pyament failed!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("cancel/{id}")]
        [HttpPut]
        public HttpResponseMessage CancelOrder(int id)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var customerId = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                var orderObj = PlaceOrderService.CancelOrder(customerId, id);
                if (orderObj != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orderObj);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order Not Cancelled!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var customerId = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                var orderList = PlaceOrderService.GetOrderDetailsDTO(customerId);
                return Request.CreateResponse(HttpStatusCode.OK, orderList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                //Getting the ID value
                var customerId = Int32.Parse(identity.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                var orderObj = PlaceOrderService.GetOrderDetailsDTO(customerId, id);
                if(orderObj != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orderObj);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order Not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
