using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLL.Services
{
    public class AgentService
    {
        public static void Create(AgentDTO a)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AgentDTO, Agent>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Agent>(a);
            DataFactory.AgentData().Create(cnv);
        }
        public static AgentDTO Get(int id)
        {

            var data = DataFactory.AgentData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Agent, AgentDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<AgentDTO>(data);
        }
        public static List<AgentDTO> Get()
        {
            var data = DataFactory.AgentData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Agent, AgentDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<AgentDTO>>(data);

        }
    
        public static void Update(AgentDTO a)
        {
            var data = DataFactory.AgentData().Get(a.Id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AgentDTO, Agent>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Agent>(a);
            DataFactory.AgentData().Update(cnv);
        }
        public static bool Delete(int id)
        {
            return DataFactory.AgentData().Delete(id);
        }
    }
}
