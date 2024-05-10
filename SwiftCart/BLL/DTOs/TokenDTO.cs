using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public string TokenString { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpireTime { get; set; }
        public string UserRole { get; set; }
        public int UserId { get; set; }
    }
}
