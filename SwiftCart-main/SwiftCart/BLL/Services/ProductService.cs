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
    public class ProductService
    {
        public static void Create(ProductDTO a)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Product>(a);
            DataFactory.ProductData().Create(cnv);
        }
        public static ProductDTO Get(int id)
        {

            var data = DataFactory.ProductData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<ProductDTO>(data);
        }

        public static List<ProductDTO> Get()
        {
            var data = DataFactory.ProductData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ProductDTO>>(data);

        }
        public static void Update(ProductDTO a)
        {
            var data = DataFactory.ProductData().Get(a.Id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Product>(a);
            DataFactory.ProductData().Update(cnv);
        }
        public static bool Delete(int id)
        {
            return DataFactory.ProductData().Delete(id);
        }
    }
}

