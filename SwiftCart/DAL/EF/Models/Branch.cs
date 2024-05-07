﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Agent> Agents { get; set; }
        public virtual List<Product> Products { get; set; }
        public Branch()
        {
            Agents = new List<Agent>();
            Products = new List<Product>();
        }
    }
}