using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReviewRepo : Repo, IRepo<Review, int, bool>
    {
        public bool Create(Review obj)
        {
            db.Reviews.Add(obj);
            return db.SaveChanges() > 0;
        }


        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Reviews.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Review Get(int id)
        {
            return db.Reviews.Find(id);
        }

        public List<Review> Get()
        {
            return db.Reviews.ToList();
        }

        public bool Update(Review obj)
        {
            var exobj = Get(obj.Id);
            if (exobj != null)
            {
                db.Entry(exobj).CurrentValues.SetValues(obj);
            }
            return db.SaveChanges() > 0;
        }


    }
}
