using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Order")]
        public int Order_Id { get; set;}
        public virtual Order Order { get; set; }
    }
}
