using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<BlogModel, Blog>()
                       .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId.Id))
                       .ForMember(dest => dest.BlogTags, opt => opt.Ignore())   // Ignore BlogTags for now
                       .ForMember(dest => dest.AuthorId, opt => opt.Ignore())   // Set AuthorId separately if needed
                       .ForMember(dest => dest.Status, opt => opt.MapFrom(src => EnumEntity.BlogStatus.Pending)) // Default status
                       .ForMember(dest => dest.View, opt => opt.MapFrom(src => 0)); // Set default view count

        }
    }
}
