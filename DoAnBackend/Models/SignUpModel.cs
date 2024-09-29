using DoAnBackend.Data;
using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Models
{
    public class SignUpModel
    {
        [Required] public string FirstName { get; set; } = null!;
        [Required] public string LastName { get; set; } = null!;

        //[DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        [Required, EmailAddress] public string Email { get; set; } = null!;
        public string? PhoneNumber {  get; set; }
        public string? Avatar { get; set; }
        [Required] public string Password { get; set; } = null!;
        [Required, Compare("Password")] public string ConfirmPassword { get; set; } = null!;
    }
    public class CreateByAdmin : SignUpModel
    {
        public string Role { get; set; } = null;
    }
}
