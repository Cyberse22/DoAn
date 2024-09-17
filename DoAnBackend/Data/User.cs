using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DoAnBackend.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public EnumEntity.Gender Gender { get; set; } = EnumEntity.Gender.Male;

        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Blog> Authors { get; set; }
    }
}
