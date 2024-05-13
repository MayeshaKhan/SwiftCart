using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SellerRepo : Repo, IRepo<Seller, int, bool>
    {
        public bool Create(Seller obj)
        {
            db.Sellers.Add(obj);
            return db.SaveChanges() > 0;
        }


        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Sellers.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Seller Get(int id)
        {
            return db.Sellers.Find(id);
        }

        public List<Seller> Get()
        {
            return db.Sellers.ToList();
        }

        public bool Update(Seller obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

    }
}
