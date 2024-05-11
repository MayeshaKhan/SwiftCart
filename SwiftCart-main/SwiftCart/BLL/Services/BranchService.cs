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
    public class BranchService
    {
        public static void Create(BranchDTO b)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BranchDTO, Branch>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Branch>(b);
            DataFactory.BranchData().Create(cnv);
        }
        public static BranchDTO Get(int id)
        {

            var data = DataFactory.BranchData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Branch, BranchDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<BranchDTO>(data);
        }
        public static List<BranchDTO> Get()
        {
            var data = DataFactory.BranchData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Branch, BranchDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<BranchDTO>>(data);

        }
        public static void Update(BranchDTO b)
        {
            var data = DataFactory.BranchData().Get(b.Id);
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BranchDTO, Branch>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Branch>(b);
             DataFactory.BranchData().Update(cnv);
        }

        public static void Delete(int id)
        {
             DataFactory.BranchData().Delete(id);
        }
    }
}
