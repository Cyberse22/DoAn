using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Models
{
    public class PasswordModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
