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
    public class OrderController : ApiController
    {
       
        [HttpPost]
        [Route("api/placeorder")]
        public HttpResponseMessage PlaceOrder(OrderDTO newOrder)
        {
            try
            {
                OrderService.PlaceOrder(newOrder);
                return Request.CreateResponse(HttpStatusCode.OK, "Order placed successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/orders")]
        public List<OrderDTO> GetOrders()
        {
            return OrderService.Get();
        }

        
    }
}

        