namespace DoAnBackend.Helpers
{
    public static class StaticEntity
    {
        public static class UserRoles
        {
            public const string Admin = "Admin";
            public const string Patient = "Patient";
            public const string Doctor = "Doctor";
            public const string Nurse = "Nurse";
        }

        public static class Status
        {
            public static string PendingConfirmation = "Pending Confirmation";
            public static string Confirmed = "Confirmed";
            public static string Cancelled = "Cancelled";
            public static string ExaminationInProgress = "Examination In Progress";
            public static string ExamCompleted = "Exam Completed";
        }

        public static class Gender 
        {
            public static string Male = "Male";
            public static string Female = "Female";
            public static string PreferNotToSay = "Prefer not to say";
        }
    }
}
