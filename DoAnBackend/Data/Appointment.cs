using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnBackend.Data
{
    public class Appointment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Reason {  get; set; }
        public DateOnly Date {  get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }

        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public string NurseId { get; set; }
        public Nurse Nurse { get; set; }

        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public Invoice Invoice { get; set; }
        public Prescription Prescription { get; set; }
    }
}
