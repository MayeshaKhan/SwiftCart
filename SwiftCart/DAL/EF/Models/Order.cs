using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Total_price { get; set; }
        [Required]
        public DateTime Order_datetime { get; set; }
        
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public virtual Customer Customer { get; set; }
       
        [ForeignKey("Seller")]
        public int Seller_id { get; set;}
        public virtual Seller Seller { get; set; }
       
        public int Branch_id { get; set;}
        
        
        public virtual List<ProductOrder> ProductOrders { get; set; }
        public Order()
        {
            ProductOrders = new List<ProductOrder>();

        }

    }
}
