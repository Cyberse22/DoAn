namespace DoAnBackend.Data
{
    public class Doctor : ApplicationUser
    {
        public string Specialization { get; set; }
        public string LicenseNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
