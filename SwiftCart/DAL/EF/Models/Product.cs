using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
       
        [ForeignKey("Category")]
        public int Category_Id { get; set; }

        public virtual  Category Category { get; set; }

        public virtual List<ProductOrder> ProductOrders { get; set; }

        public virtual List<BranchProduct> BranchProducts{ get; set; }

        public virtual List<Review> Reviews { get; set; }
        public Product()
        {
            ProductOrders = new List<ProductOrder>();
            BranchProducts = new List<BranchProduct>();
            Reviews = new List<Review>();


            

        }
    }
}
