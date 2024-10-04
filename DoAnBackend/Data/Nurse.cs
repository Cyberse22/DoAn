namespace DoAnBackend.Data
{
    public class Nurse : ApplicationUser
    {
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<Shift>? Shifts { get; set; }
    }
}
