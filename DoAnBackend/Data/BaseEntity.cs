namespace DoAnBackend.Data
{
    public class BaseEntity
    {
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
        public DateTime updatedDate { get; set; } = DateTime.UtcNow;
        public bool isActive { get; set; } = true;

        public string GetFormattedCreatedDate()
        {
            return createdDate.ToString("mm:HH dd/MM/yyyy");
        }

        public string GetFormattedUpdatedDate()
        {
            return updatedDate.ToString("mm:HH dd/MM/yyyy");
        }
    }
}
