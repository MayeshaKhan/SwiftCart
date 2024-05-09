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
    public class CategoryService
    {
        public static void Create(CategoryDTO a)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Category>(a);
            DataFactory.CategoryData().Create(cnv);
        }
        public static CategoryDTO Get(int id)
        {

            var data = DataFactory.CategoryData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CategoryDTO>(data);
        }
        public static List<CategoryDTO> Get()
        {
            var data = DataFactory.CategoryData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CategoryDTO>>(data);

        }

        public static void Update(CategoryDTO a)
        {
            var data = DataFactory.CategoryData().Get(a.Id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Category>(a);
            DataFactory.CategoryData().Update(cnv);
        }
        public static bool Delete(int id)
        {
            return DataFactory.CategoryData().Delete(id);
        }
    }
}
