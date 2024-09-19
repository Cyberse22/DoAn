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
        Task<bool> AssignRoleAsync(User user, string role);
    }
}
