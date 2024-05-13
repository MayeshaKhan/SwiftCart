using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID, RET>
    {
        RET Create(CLASS obj);
        CLASS Get(ID id);
        List<CLASS> Get();
        RET Update(CLASS obj);
        RET Delete(ID id);
    }
}
