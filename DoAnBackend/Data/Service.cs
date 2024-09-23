using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class Service : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public ICollection<InvoiceService>? InvoiceServices { get; set; }
    }
}
