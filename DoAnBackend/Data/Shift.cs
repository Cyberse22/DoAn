namespace DoAnBackend.Data
{
    public class Shift : BaseEntity
    {
        public string? ShiftName { get; set; }
        public string? ShiftType { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string? NurseId { get; set; }
        public string? NurseName { get; set; }
        public Nurse? Nurse { get; set; }
        public string? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
