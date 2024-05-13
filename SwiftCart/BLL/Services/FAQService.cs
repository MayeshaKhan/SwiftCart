using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FAQService
    { 
        public static void Create(FaqDTO a)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FaqDTO, FAQ>();
        });
        var mapper = new Mapper(config);
        var cnv = mapper.Map<FAQ>(a);
        DataFactory.FAQData().Create(cnv);
    }
    public static FaqDTO Get(int id)
    {

        var data = DataFactory.FAQData().Get(id);
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FAQ, FaqDTO>();
        });
        var mapper = new Mapper(config);
        return mapper.Map<FaqDTO>(data);
    }
    public static List<FaqDTO> Get()
    {
        var data = DataFactory.FAQData().Get();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FAQ, FaqDTO>();
        });
        var mapper = new Mapper(config);
        return mapper.Map<List<FaqDTO>>(data);

    }

    public static void Update(FaqDTO a)
    {
        var data = DataFactory.FAQData().Get(a.Id);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FaqDTO, FAQ>();
        });
        var mapper = new Mapper(config);
        var cnv = mapper.Map<FAQ>(a);
        DataFactory.FAQData().Update(cnv);
    }
    public static bool Delete(int id)
    {
        return DataFactory.FAQData().Delete(id);
    }
}
}
