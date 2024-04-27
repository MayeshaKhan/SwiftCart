using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
namespace DAL.Repos
{
    public class Repo
    {
        protected SwiftCartContext db;
        public Repo()
        {
            db = new SwiftCartContext();
        }
    }
}
