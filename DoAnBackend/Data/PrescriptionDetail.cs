using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class PrescriptionDetail : BaseEntity
    {
        [Required]
        public int Quantity { get; set; }

        public Guid PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }

        public Guid MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
    }
}
