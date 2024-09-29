using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }
    }
    public class ApplicationRole : IdentityRole 
    { 
        public string? RoleName {  get; set; }
        public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }
    }
    public class ApplicationUserRole : IdentityRole 
    {
        public virtual ApplicationUser? User { get; set; }
        public virtual ApplicationRole? Role { get; set; }
    }
}
