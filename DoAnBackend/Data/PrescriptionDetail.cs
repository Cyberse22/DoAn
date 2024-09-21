using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class PrescriptionDetail : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }

        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}
