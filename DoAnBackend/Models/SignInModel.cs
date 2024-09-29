using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Models
{
    public class SignInModel
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
