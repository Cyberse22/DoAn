using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class PrescriptionDetail : BaseEntity
    {
        public Guid PrescriptionId { get; set; }
        public string? PrescriptionName { get; set; }
        public Prescription? Prescription { get; set; }

        public int Quantity { get; set; }
        public Guid MedicineId { get; set; }
        public string? MedicineID { get; set; }
        public string? MedicineName { get; set; }
        public string? Unit { get; set; }
        public Medicine? Medicine { get; set; }
    }
}
