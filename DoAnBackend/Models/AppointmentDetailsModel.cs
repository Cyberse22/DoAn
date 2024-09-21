namespace DoAnBackend.Models
{
    public class AppointmentDetailsModel
    {
        public int PatientId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }

        public DateOnly DOB { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }

        public int DoctorId { get; set; }
        public DateOnly Date { get; set; }
        public string Reason { get; set; }
    }
}
