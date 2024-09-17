using DoAnBackend.Models;
using Microsoft.AspNetCore.Identity;

namespace DoAnBackend.Services.Interface
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
