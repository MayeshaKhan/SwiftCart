using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BranchProductRepo : Repo, IRepo<BranchProduct, int, bool>
    {
        public bool Create(BranchProduct obj)
        {
            db.BranchProducts.Add(obj);
            return db.SaveChanges() > 0;
        }


        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.BranchProducts.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public BranchProduct Get(int id)
        {
            return db.BranchProducts.Find(id);
        }

        public List<BranchProduct> Get()
        {
            return db.BranchProducts.ToList();
        }

        public bool Update(BranchProduct obj)
        {
            var exobj = Get(obj.Id);
           db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

       
    }
}

