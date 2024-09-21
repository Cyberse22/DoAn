using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class Prescription : BaseEntity
    {
        [Key]   
        public int Id { get; set; }
        public string Diagnsis { get; set; }
        public DateOnly? NextAppointment { get; set; }

        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        
        public ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
        public Invoice Invoice { get; set; }
    }
}
