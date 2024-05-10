using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class TokenRepo : Repo, IRepo<Token, int, bool>
    {
        public void Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var exObj = Get(id);
            db.Tokens.Remove(exObj);
            return db.SaveChanges() > 0;
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public bool Update(Token obj)
        {
            var exObj = Get(obj.Id);
            db.Tokens.Remove(exObj);
            return db.SaveChanges() > 0;
        }
    }
}
