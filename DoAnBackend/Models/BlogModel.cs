using DoAnBackend.Data;
using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set;}
        public EnumEntity.BlogStatus Status { get; set; }
        public Category CategoryId { get; set; }
        public Tag TagId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int View {  get; set; }
    }
}
