namespace DoAnBackend.Models
{
    public class PrescriptionModel
    {
        public string? PrescriptionName { get; set; }
        public string? Diagnsis { get; set; }
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
            public string? MedicineName { get; set; }
            public int Quantity { get; set; }
        }
        public class CreatePrescription
        {
            public string? AppointmentName { get; set; }
            public string? Diagnsis { get; set; }
            public DateOnly? NextAppointment { get; set; }
        }
    }
}
