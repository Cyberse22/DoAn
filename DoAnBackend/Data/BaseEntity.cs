namespace DoAnBackend.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public bool isActive { get; set; } = true;
    }
}
