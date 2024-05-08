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
        public static IRepo<Agent, int, bool> AgentData()
        {
            return new AgentRepo();
        }
        public static IRepo<Branch, int, bool> BranchData()
        {
            return new BranchRepo();
        }

        /*public static IRepo<Category, int, bool> CategoryData()
        {
            return new CategoryRepo();
        }
        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }*/

    }
}
