using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Branch")]
        public int BId { get; set; }
        public virtual Branch Branch{ get; set; }
    }
}