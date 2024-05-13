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
        public static bool Registration(CustomerDTO a)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Customer>(a);
            return DataFactory.CustomerData().Create(cnv);
          


        }
       
    }
}
