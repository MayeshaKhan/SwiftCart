using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class SwiftCartContext : DbContext
    {
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Branch> Branches { get; set; }
        
    }
}
