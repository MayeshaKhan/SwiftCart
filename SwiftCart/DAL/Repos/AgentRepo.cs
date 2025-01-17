﻿using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AgentRepo : Repo, IRepo<Agent, int, bool>
    {
        public bool Create(Agent obj)
        {
            db.Agents.Add(obj);
            return db.SaveChanges() > 0;
        }

        
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Agents.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Agent Get(int id)
        {
            return db.Agents.Find(id);
        }

        public List<Agent> Get()
        {
            return db.Agents.ToList();
        }

        public bool Update(Agent obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        

       
    }
}

