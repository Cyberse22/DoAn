using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class InvoiceMedicine : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}
