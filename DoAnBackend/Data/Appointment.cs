using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnBackend.Data
{
    public class Appointment : BaseEntity
    {
        public string? Reason {  get; set; }
        public DateOnly? AppointmentDate {  get; set; }
        public int Number { get; set; }
        public string? Status { get; set; }

        public string? PatientId { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientName { get; set; }
        public Patient? Patient { get; set; }

        public string? NurseId { get; set; }
        public string? NurseFirstName { get; set; }
        public string? NurseLastName { get; set; }
        public Nurse? Nurse { get; set; }

        public string? DoctorId { get; set; }
        public string? DoctorFirstName { get; set; }
        public string? DoctorLastName { get; set; }
        public Doctor? Doctor { get; set; }

        public Invoice? Invoice { get; set; }
        public Prescription? Prescription { get; set; }
    }
}
