using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class InvoiceService : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public int InvoicedId { get; set; }
        public Invoice Invoice { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
