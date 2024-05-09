using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderRepo : Repo, IRepo<Order,int,bool> 

    {
        public void Create(Order obj)
        {
            db.Orders.Add(obj);
            db.SaveChanges();
        }


        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Orders.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        public bool Update(Order obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
