﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductOrderDTO
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int Product_Id { get; set; }
    }
}
