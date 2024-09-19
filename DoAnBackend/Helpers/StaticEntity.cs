namespace DoAnBackend.Helpers
{
    public static class StaticEntity
    {
        public static class UserRoles
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }

        public static class BlogStatus 
        {
            public static string Publish = "Publish";
            public static string Draft = "Draft";
            public static string Pending = "Pending";
        }

        public static class Gender 
        {
            public static string Male = "Male";
            public static string Female = "Female";
            public static string PreferNotToSay = "Prefer not to say";
        }
    }
}
