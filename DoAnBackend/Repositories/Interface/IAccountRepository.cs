using DoAnBackend.Data;
using DoAnBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace DoAnBackend.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<SignInResult> SignInAsync(string email, string password);
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<IdentityResult> CreateAdminAsync(SignUpModel model);
        Task<bool> AssignRoleAsync(ApplicationUser user, string role);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task UpdateUserAsync(ApplicationUser user);
        Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword);
        Task<IdentityResult> CreateUserByAdminAsync(CreateByAdmin model);
        Task<CurrentUserDetailModel> GetUserDetailsByIdAndEmailAsync(string userId, string email);
        Task<CurrentUserDetailModel> GetAppointmentsByPatientEmailAsync(string email);
        Task<CurrentUserDetailModel> GetCurrentUserByEmailAsync(string email);
        Task<ApplicationUser> GetCurrentUserByEmailAsync2(string email);
        Task<string> GetUserRoleAsync(string userId);
    }
}
