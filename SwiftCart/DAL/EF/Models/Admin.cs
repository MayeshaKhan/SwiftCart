﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Admin
    {
       
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        
       


    }
}
