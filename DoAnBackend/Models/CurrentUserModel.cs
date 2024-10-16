﻿namespace DoAnBackend.Models
{
    public class CurrentUserModel
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }

    public class CurrentUserDetailModel : CurrentUserModel
    { 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }

}
