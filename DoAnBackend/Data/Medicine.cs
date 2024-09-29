using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class Medicine : BaseEntity
    {
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public decimal? Price { get; set; }

        public ICollection<PrescriptionDetail>? PrescriptionDetails { get; set; }
        public ICollection<InvoiceMedicine>? InvoiceMedicines { get; set; }
    }
}
