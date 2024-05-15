using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataFactory
    {
        public static IRepo<Admin, int, bool> AdminData()
        {
            return new AdminRepo();
        }
        public static IRepo<Agent, int, bool> AgentData()
        {
            return new AgentRepo();
        }
        public static IRepo<Branch, int, bool> BranchData()
        {
            return new BranchRepo();
        }
        public static IRepo<BranchProduct, int, bool> BranchProductData()
        {
            return new BranchProductRepo();
        }

        public static IRepo<Category, int, bool> CategoryData()
        {
            return new CategoryRepo();
        }
        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }

        public static IRepo<Order, int, bool> OrderData()
        {
            return new OrderRepo();
        }
        public static IRepo<Customer, int, bool> CustomerData()
        {
            return new CustomerRepo();
        }

        public static IRepo<Seller, int, bool> SellerData()
        {
            return new SellerRepo();
        }
        public static IRepo<Token, int, bool> TokenData()
        {
            return new TokenRepo();
        }

        public static IRepo<FAQ, int, bool> FAQData()
        {
            return new FAQRepo();
        }
        public static IRepo<Review, int, bool> ReviewData()
        {
            return new ReviewRepo();
        }


    }
}
