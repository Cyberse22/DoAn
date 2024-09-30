using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using System.Globalization;

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
            CreateMap<Appointment, AppointmentModel>()
                    .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.PatientEmail))
                    .ForMember(dest => dest.NurseName, opt => opt.MapFrom(src => $"{src.NurseFirstName} {src.NurseLastName}"))
                    .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => $"{src.DoctorFirstName} {src.DoctorLastName}"))
                    .ReverseMap();
            CreateMap<AppointmentModel.CreateAppointmentModel, Appointment>()
                    .ReverseMap();
            CreateMap<Appointment, AppointmentModel.CreateAppointmentModel>()
                    .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.AppointmentDate))
                    .ForMember(dest => dest.Reason, opt => opt.MapFrom(src => src.Reason))
                    .ReverseMap();
            CreateMap<Medicine, MedicineModel>().ReverseMap();
            CreateMap<MedicineModel, Medicine>().ReverseMap();
            CreateMap<PrescriptionModel, Prescription>().ReverseMap();
            CreateMap<Prescription, PrescriptionModel>()
                    .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName))
                    .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
                    .ReverseMap();
            CreateMap<PrescriptionDetail, PrescriptionModel.PrescriptionDetailModel>()
                    .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                    .ReverseMap();
        }
    }
}
