using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PlaceOrderService
    {
        public static string PlaceOrder(int customerId, PlaceOrderDTO obj)
        {
            var newOrder = new Order();
            newOrder.Branch_id = obj.Branch_id;
            newOrder.Customer_Id = customerId;
            newOrder.Status = "ordered";
            newOrder.Order_datetime = DateTime.Now;
            newOrder.Total_price = 0;
            foreach(var placeProductObj in obj.productList)
            {
                var productObj = DataFactory.ProductData().Get(placeProductObj.Product_Id);
                if(productObj == null) { throw new ObjectNotFoundException("Product Not found"); }
                // placing product
                newOrder.Total_price += (int)(productObj.Price * placeProductObj.Quantity);
                var productOrderObj = new ProductOrder()
                {
                    Product_Id = productObj.Id,
                    Price= productObj.Price,
                    Quantity = placeProductObj.Quantity,
                };
                newOrder.ProductOrders.Add(productOrderObj);
            }
            if (DataFactory.OrderData().Create(newOrder))
            {
                return "New order created with id: " + newOrder.Id;
            }
            else
            {
                return null;
            }
        }
        public static List<OrderDetatilsDTO> GetOrderDetailsDTO(int customerId)
        {
            var OrderObj = DataFactory.OrderData().Get().Where(x=>x.Customer_Id.Equals(customerId)).ToList();
            if(OrderObj == null) { return null; }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDetatilsDTO>();
                cfg.CreateMap<ProductOrder, ProductOrderDTO>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<List<OrderDetatilsDTO>>(OrderObj);
            return cnv;
        }
        public static OrderDetatilsDTO GetOrderDetailsDTO(int orderId, int customerId)
        {
            var OrderObj = DataFactory.OrderData().Get(orderId);
            if (OrderObj == null || OrderObj.Customer_Id != customerId) { return null; }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<ProductOrder, ProductOrderDTO>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<OrderDetatilsDTO>(OrderObj);
            return cnv;
        }

        public static string CancelOrder(int customerId, int orderId)
        {
            var OrderObj = DataFactory.OrderData().Get(orderId);
            if (OrderObj == null || OrderObj.Customer_Id != customerId || OrderObj.Status.Equals("paid")) { return null; }
            // cancelling order
            OrderObj.Status = "cancelled";
            if (DataFactory.OrderData().Update(OrderObj))
            {
                return "Order is cancelled!";
            }
            return null;
        }

        public static string PaymentOrder(int customerId, int orderId)
        {
            var OrderObj = DataFactory.OrderData().Get(orderId);
            if (OrderObj == null || OrderObj.Customer_Id != customerId || OrderObj.Status.Equals("cancelled")) { return null; }
            // cancelling order
            OrderObj.Status = "paid";
            if (DataFactory.OrderData().Update(OrderObj))
            {
                return "Order is paid!";
            }
            return null;
        }
    }
}
