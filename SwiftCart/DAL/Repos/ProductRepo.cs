using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public void Create(Product obj)
        {
            db.Products.Add(obj);
            db.SaveChanges();
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Products.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        

        public bool Update(Product obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
