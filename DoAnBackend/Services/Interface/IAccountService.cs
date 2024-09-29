using DoAnBackend.Data;
using DoAnBackend.Models;
using Microsoft.AspNetCore.Identity;

namespace DoAnBackend.Services.Interface
{
    public interface IAccountService
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<string> SignInAsync(SignInModel model);
        Task<IdentityResult> CreateAdminAsync(SignUpModel model);
        Task<bool> AssignRoleAsync(ApplicationUser user, string role);
        Task<string> GetUserByEmailAsync(string email);
        Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword);
        Task<IdentityResult> CreateUserByAdminAsync(CreateByAdmin model);    
        Task<CurrentUserDetailModel> GetUserDetailsByIdAndEmailAsync(string userId, string email);
        Task<CurrentUserDetailModel?> GetUserDetailsByEmailAsync(string email);
    }
}
