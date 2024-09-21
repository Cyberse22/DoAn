using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class Service : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public ICollection<InvoiceService> InvoiceServices { get; set; }
    }
}
