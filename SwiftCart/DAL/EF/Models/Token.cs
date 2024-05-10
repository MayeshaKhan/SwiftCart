using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string TokenString { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpireTime { get; set; }
        public string UserRole { get; set; }
        public int UserId { get; set; }
    }
}
