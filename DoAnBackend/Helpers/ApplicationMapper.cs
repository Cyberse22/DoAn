using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using System.Globalization;
using static DoAnBackend.Models.PrescriptionModel;

namespace DoAnBackend.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<ApplicationUser, UserDetailModel>().ReverseMap();
            CreateMap<ApplicationUser, CurrentUserModel>().ReverseMap();
            CreateMap<PasswordModel, SignInModel>().ReverseMap();
            CreateMap<Appointment, AppointmentModel>()
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
                    .ReverseMap()
                    .ForMember(dest => dest.Medicine, opt => opt.Ignore());
            CreateMap<Shift, ShiftModel>()
                    .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString("HH:mm")))
                    .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString("HH:mm")))
                    .ReverseMap();
            CreateMap<ShiftModel.CreateShiftModel, Shift>()
                    .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.ParseExact(src.StartTime, "HH:mm")))
                    .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeOnly.ParseExact(src.EndTime, "HH:mm")))
                    .ReverseMap();
            CreateMap<Medicine, MedicineModel>()
            .ForMember(dest => dest.MedicineID, opt => opt.MapFrom(src => src.MedicineID))
            .ReverseMap();

            // Mapping cho PrescriptionDetail
            CreateMap<PrescriptionDetail, PrescriptionDetailModel>()
                .ForMember(dest => dest.MedicineID, opt => opt.MapFrom(src => src.MedicineId))
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Medicine.Unit))
                .ReverseMap();

            // Mapping cho Prescription
            CreateMap<Prescription, PrescriptionModel>()
                .ForMember(dest => dest.PrescriptionDetails, opt => opt.MapFrom(src => src.PrescriptionDetails))
                .ReverseMap();

            // Mapping cho CreatePrescriptionDetailModel
            CreateMap<PrescriptionModel.CreatePrescriptionDetails, PrescriptionDetail>()
                .ForMember(dest => dest.MedicineId, opt => opt.MapFrom(src => src.MedicineID))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ReverseMap();
        }
    }
}
