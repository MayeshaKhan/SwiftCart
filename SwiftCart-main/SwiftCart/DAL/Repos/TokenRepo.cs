using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Token Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }
        public Token Read(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.TKey.Equals(id));
        }
        public Token Update(Token obj)
        {
            var token = Read(obj.TKey);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return token;
                    return null;

        }

        void IRepo<Token, string, Token>.Create(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}
