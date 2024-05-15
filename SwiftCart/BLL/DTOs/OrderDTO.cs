using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int Total_price { get; set; }
        public DateTime Order_datetime { get; set; }

        public int Customer_Id { get; set; }

        public int Seller_id { get; set; }

        public int Branch_id { get; set; }

    }
}
