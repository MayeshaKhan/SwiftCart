using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FaqDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
