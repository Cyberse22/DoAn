using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class Medicine : BaseEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Unit { get; set; }
        [Required]
        public decimal? Price { get; set; }

        public ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
        public ICollection<InvoiceMedicine> InvoiceMedicines { get; set; }
    }
}
