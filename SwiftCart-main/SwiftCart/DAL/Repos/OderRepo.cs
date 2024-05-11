using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class OrderRepo : Repo, IOrderRepo<Order, int, bool>
    {
        public void PlaceOrder(Order obj)
        {
            db.Orders.Add(obj);
            db.SaveChanges();
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

