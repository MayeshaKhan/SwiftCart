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
    public class CustomerService
    {
        public static void Create(CustomerDTO a)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Customer>(a);
            DataFactory.CustomerData().Create(cnv);
        }
        public static CustomerDTO Get(int id)
        {

            var data = DataFactory.CustomerData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CustomerDTO>(data);
        }

        public static List<CustomerDTO> Get()
        {
            var data = DataFactory.CustomerData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CustomerDTO>>(data);

        }
        public static void Update(CustomerDTO a)
        {
            var data = DataFactory.CustomerData().Get(a.Id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Customer>(a);
            DataFactory.CustomerData().Update(cnv);
        }
        public static bool Delete(int id)
        {
            return DataFactory.CustomerData().Delete(id);
        }
    }
}
