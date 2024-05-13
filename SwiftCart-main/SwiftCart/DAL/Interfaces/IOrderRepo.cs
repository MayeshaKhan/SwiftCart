using DAL.EF.Models;
using DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderRepo<CLASS,ID,RET>
    {
        void PlaceOrder(CLASS obj);
        CLASS Get(ID id);
        List<CLASS> Get();
        RET Update(CLASS obj);

    }
}
