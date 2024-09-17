using DoAnBackend.Data;
using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Models
{
    public class SignUpModel
    {
        [Required] public string FirstName { get; set; } = null!;
        [Required] public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; } 
        public EnumEntity.Gender Gender { get; set; }
        [Required, EmailAddress] public string Email { get; set; } = null!;
        [Required] public string UserName { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
        [Required, Compare("Password")] public string ConfirmPassword { get; set; } = null!;
    }
}
