namespace DoAnBackend.Models
{
    public class ChangePasswordResultModel
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        
    }
}
