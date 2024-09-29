namespace DoAnBackend.Models
{
    public class PrescriptionModel
    {
        public Guid? Id { get; set; }
        public string? Diagnsis { get; set; }
        public DateOnly? NextAppointment { get; set; }
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public ICollection<PrescriptionDetailModel>? PrescriptionDetails { get; set; }

        public class PrescriptionDetailModel
        {
            public string? MedicineName { get; set; }
            public int Quantity { get; set; }
        }
    }
}
