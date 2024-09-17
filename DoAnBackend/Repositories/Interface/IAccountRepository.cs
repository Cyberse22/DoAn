using DoAnBackend.Models;
using Microsoft.AspNetCore.Identity;

namespace DoAnBackend.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<SignInResult> SignInAsync(string email, string password);
        Task<IdentityResult> SignUpAsync(SignUpModel model);
    }
}
