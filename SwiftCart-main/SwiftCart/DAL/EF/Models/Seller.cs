using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Seller
    {
        
        public int Id { get; set; }
       

        public string Name { get; set; }
       
        public string Username { get; set; }
        
        public string Password { get; set; }

        public virtual List<Order> Orders { get; set; }



        public Seller()
        {
            Orders = new List<Order>();
        }

    }
}
