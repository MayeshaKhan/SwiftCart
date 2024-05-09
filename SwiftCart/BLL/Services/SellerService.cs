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
    public class SellerService
    {
        public static void Create(SellerDTO a)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SellerDTO, Seller>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Seller>(a);
            DataFactory.SellerData().Create(cnv);
        }
        public static SellerDTO Get(int id)
        {

            var data = DataFactory.SellerData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Seller, SellerDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<SellerDTO>(data);
        }
        public static List<SellerDTO> Get()
        {
            var data = DataFactory.SellerData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Seller, SellerDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<SellerDTO>>(data);

        }

        public static void Update(SellerDTO a)
        {
            var data = DataFactory.SellerData().Get(a.Id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SellerDTO, Seller >();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Seller>(a);
            DataFactory.SellerData().Update(cnv);
        }
        public static bool Delete(int id)
        {
            return DataFactory.SellerData().Delete(id);
        }
    }
}
