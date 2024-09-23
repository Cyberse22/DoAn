using DoAnBackend.Models;
using DoAnBackend.Services.Interface;
using System.Security.Claims;

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

    public static class Helper
    {
        public static async Task<CurrentUserModel> CreateCurrentUserModel(IAccountService _accountService, ClaimsPrincipal user)
        {
            var email = user.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
            {
                throw new InvalidOperationException("Không tìm thấy email trong claims."); // Ném exception nếu không tìm thấy email
            }

            var userId = await _accountService.GetUserByEmailAsync(email);

            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("Người dùng không tìm thấy."); // Ném exception nếu không tìm thấy người dùng
            }

            return new CurrentUserModel
            {
                Id = userId,
                Email = email
            };
        }

        internal static object CreateCurrentUserModel(object accountService, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
    
}
