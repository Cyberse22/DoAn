using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class Prescription : BaseEntity
    {
        public string? PrescriptionName { get; set; }
        public string? Diagnsis { get; set; }
        public DateOnly? NextAppointment { get; set; }

        public string? PatientId { get; set; }
        public string? PatientName { get; set; }
        public Patient? Patient { get; set; }

        public string? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorEmail { get; set; }
        public Doctor? Doctor { get; set; }

        public Guid AppointmentId { get; set; }
        public string? AppointmentName { get; set; }
        public Appointment? Appointment { get; set; }
        
        public ICollection<PrescriptionDetail>? PrescriptionDetails { get; set; }
        public Invoice? Invoice { get; set; }
    }
}
