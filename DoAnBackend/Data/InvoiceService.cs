using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class InvoiceService : BaseEntity
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public Guid InvoicedId { get; set; }
        public Invoice? Invoice { get; set; }

        public Guid ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
