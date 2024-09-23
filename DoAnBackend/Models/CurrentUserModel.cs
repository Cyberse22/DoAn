namespace DoAnBackend.Models
{
    public class CurrentUserModel
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? CurrentPatientId { get; set; }
        public string? CurrentNurseId { get; set; }
        public string? CurrentDoctorId { get; set; }
    }

    public class CurrentUserDetailModel
    { 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        
    }

}
