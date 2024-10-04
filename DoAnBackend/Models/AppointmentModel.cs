using DoAnBackend.Data;
using DoAnBackend.Helpers;
using DoAnBackend.Services;
using DoAnBackend.Services.Interface;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace DoAnBackend.Models
{
    public class AppointmentModel
    {
        public Guid? Id { get; set; }
        public string? AppointmentName { get; set; }
        public string? Reason { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public int Number { get; set; }
        public string? Status { get; set; }
        public string? PatientId { get; set; }
        public string? NurseId { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientEmail { get; set; }
        public string? NurseName { get; set; }
        public string? NurseEmail { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorEmail { get; set; }


        public class CreateAppointmentModel
        {
            public string? Reason { get; set; }
            //[DataType(DataType.Date)]
            //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateOnly AppointmentDate { get; set; }
        }
    }
}
