using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class InvoiceMedicine : BaseEntity
    {
        [Required]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        public Guid MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
    }
}
