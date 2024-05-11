using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Services.CustomerService;

namespace BLL.Services
{



    public class CustomerService
    {
        public static void SignUp(CustomerDTO newCustomer)
        {
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(config);
            var customerEntity = mapper.Map<Customer>(newCustomer);


            DataFactory.CustomerData().SignUp(customerEntity);
        }


    }
}
