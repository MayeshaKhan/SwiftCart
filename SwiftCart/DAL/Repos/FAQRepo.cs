using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FAQRepo : Repo, IRepo<FAQ, int, bool>
    {
        public bool Create(FAQ obj)
        {
            db.FAQs.Add(obj);
            return db.SaveChanges() > 0;
        }


        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.FAQs.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public FAQ Get(int id)
        {
            return db.FAQs.Find(id);
        }

        public List<FAQ> Get()
        {
            return db.FAQs.ToList();
        }

        public bool Update(FAQ obj)
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
