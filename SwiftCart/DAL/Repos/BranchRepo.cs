using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BranchRepo : Repo, IRepo<Branch, int, bool>
    {
        public bool Create(Branch obj)
        {
            db.Branches.Add(obj);
            return db.SaveChanges() > 0;
        }


        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Branches.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Branch Get(int id)
        {
            return db.Branches.Find(id);
        }

        public List<Branch> Get()
        {
            return db.Branches.ToList();
        }

        public bool Update(Branch obj)
        {
            var exobj = Get(obj.Id);
           db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

       
    }
}

