namespace DoAnBackend.Models
{
    public class InvoiceModel
    {
        public int? AppointmentId { get; set; }
        public int? PatientId { get; set; }

        public int Id { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public IList<Medicine> Medicines { get; set; }
        public int ServiceId { get; set; }

        public int ServiceQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal MedicinePrice { get; set; }
        public string ServiceName { get; set; }
    }
    public class Medicine
    {
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

}
