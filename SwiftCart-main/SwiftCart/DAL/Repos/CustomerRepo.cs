using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    
    internal class CustomerRepo : Repo, ICustomerRepo<Customer, int, bool>, IAuth<bool>
     {
        public  bool Authenticate(string username, string password)
        {
            var data=db.Customers.FirstOrDefault(u=>u.Username.Equals(username) && u.Password.Equals(password));
            if (data !=null) return true;
            return false;
        }
      public void SignUp(Customer obj)
      {
        db.Customers.Add(obj);
        db.SaveChanges();
      }

    public Customer Get(int id)
    {
        return db.Customers.Find(id);
    }
    public List<Customer> Get()
    {
        return db.Customers.ToList();
    }

    public bool Update(Customer obj)
    {
        var exobj = Get(obj.Id);
        db.Entry(exobj).CurrentValues.SetValues(obj);
        return db.SaveChanges() > 0;
    }
        public void AddLoginRecord(Login loginRecord)
        {
            // Add a new login record to the database
            db.Logins.Add(loginRecord);
            db.SaveChanges();
        }

    }
}
