namespace DoAnBackend.Models
{
    public class ShiftModel
    {
        public Guid? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? NurseId { get; set; }
        public string? NurseName { get; set; }
        public string? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public class CreateShiftModel
        {
            public string? ShiftType { get; set; }
            public string? StartTime { get; set; }
            public string? EndTime { get; set; }
            public string? NurseName { get; set; }
            public string? DoctorName { get; set; }
        }
    }
}
