namespace DoAnBackend.Models
{
    public class DoctorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
    }
}
