namespace DoAnBackend.Data
{
    public class Notification : BaseEntity
    {
        public string? Message { get; set; }
        public bool IsRead { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
