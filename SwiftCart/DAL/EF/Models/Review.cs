using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Product")]
        public int  Product_Id { get; set;}
        public virtual Product Product { get; set; }
    }
}
