using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataFactory
    {
        public static IRepo<Agent, int, bool> AgentData()
        {
            return new AgentRepo();
        }
        public static IRepo<Branch, int, bool> BranchData()
        {
            return new BranchRepo();
        }

        public static ICustomerRepo<Customer, int, bool> CustomerData()
        {
            return new CustomerRepo();
        }


        public static IAuth<bool> AuthData()
        {
            return new CustomerRepo();


        }
        
        public static IOrderRepo<Order,int,bool> OrderData()
        {
           return new OrderRepo();
        }
        /*public static IRepo<Token,string,Token> TokenData()
        {

            return new TokenRepo();
        }*/
        public static IProductRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();

        }



    }
}

