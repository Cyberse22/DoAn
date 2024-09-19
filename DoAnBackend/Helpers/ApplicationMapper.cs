using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<BlogModel, Blog>();
            CreateMap<CategoryModel, Category>().ReverseMap();
        }
    }
}
