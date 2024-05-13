

using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService 
    {
        public static void PlaceOrder(OrderDTO newOrder)
        {

            var config = new MapperConfiguration(cfg =>
            {
            
                cfg.CreateMap<ProductOrderDTO, ProductOrder>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<ProductOrder>(newOrder);


            var existingProduct = DataFactory.ProductData().Get(cnv.Id);
            if (existingProduct == null)
            {
                throw new Exception("Product does not exist.");
            }


            DataFactory.ProductOrderData().PlaceOrder(cnv);
        }
        public static List<OrderDTO> Get()
        {
            var data = DataFactory.ProductOrderData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductOrder, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);

        }

        
    }
}




