using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<ApplicationUser, UserDetailModel>().ReverseMap();
            CreateMap<ApplicationUser, CurrentUserModel>().ReverseMap();
            CreateMap<CurrentUserModel, TempModel>().ReverseMap();
            CreateMap<PasswordModel, SignInModel>().ReverseMap();
            CreateMap<AppointmentModel, Appointment>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.HasValue ? DateOnly.FromDateTime(src.Date.Value) : default(DateOnly)))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.TimeSpan.HasValue ? src.TimeSpan.Value : default(TimeSpan)))
                .ForMember(dest => dest.Reason, opt => opt.MapFrom(src => src.Reason))
                .ReverseMap()
                .ForMember(dest => dest.TimeSpan, opt => opt.MapFrom(src => src.Time));

            CreateMap<AppointmentModel.AppointmentDetails, Appointment>()
                .ReverseMap();
            CreateMap<DateOnly, DateTime>().ConvertUsing(d => d.ToDateTime(TimeOnly.MinValue));
            CreateMap<DateTime, DateOnly>().ConvertUsing(d => DateOnly.FromDateTime(d));
        }
    }
}
