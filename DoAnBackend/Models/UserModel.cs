namespace DoAnBackend.Models
{
    public class UserModel
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Avatar { get; set; }
    }
    public class UserDetailModel : UserModel
    {
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
