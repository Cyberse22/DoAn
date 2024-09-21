using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class Invoice : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public string NurseId {  get; set; }
        public Nurse Nurse { get; set; }

        public ICollection<InvoiceService> InvoiceServices { get; set; }
        public ICollection<InvoiceMedicine> InvoiceMedicines { get; set; }
    }
}
