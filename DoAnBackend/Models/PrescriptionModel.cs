namespace DoAnBackend.Models
{
    public class PrescriptionModel
    {
        public string? PrescriptionName { get; set; }
        public string? Conclusion { get; set; }
        public DateOnly? NextAppointment { get; set; }

        public string? PatientId { get; set; }
        public string? PatientName { get; set; }

        public string? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorEmail { get; set; }

        public string? AppointmentId { get; set; }
        public string? AppointmentName { get; set; }

        public ICollection<PrescriptionDetailModel>? PrescriptionDetails { get; set; }

        public class PrescriptionDetailModel
        {
            public string MedicineID { get; set; }
            public string? MedicineName { get; set; }
            public string? Unit { get; set; }
            public int Quantity { get; set; }
        }
        public class CreatePrescription
        {
            public string? AppointmentName { get; set; }
            public string? Conclusion { get; set; }
            public DateOnly? NextAppointment { get; set; }
        }
        public class CreatePrescriptionDetails
        {
            public string? PrescriptionName { get; set; }
            public string MedicineID { get; set; }
            public string? Unit {  get; set; }
            public int Quantity { get; set; }
        }
    }
}
