using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PlaceOrderDTO
    {
        public int Branch_id { get; set; }
        public List<PlaceProductDTO> productList { get; set; }
    }
}
