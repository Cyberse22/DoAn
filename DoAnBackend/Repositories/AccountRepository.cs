using DoAnBackend.Data;
using DoAnBackend.Helpers;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoAnBackend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateAdminAsync(SignUpModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                Gender = model.Gender,
            };
            
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(StaticEntity.UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(StaticEntity.UserRoles.Admin));
                }

                await _userManager.AddToRoleAsync(user, StaticEntity.UserRoles.Admin);
            }
            return result;
        }

        public async Task<SignInResult> SignInAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) 
            {
                return SignInResult.Failed;
            }
            var passwordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!passwordValid)
            {
                return SignInResult.Failed;
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>();
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            return await _signInManager.PasswordSignInAsync(email, password, false, false);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                Gender = model.Gender
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) 
            {
                if(!await _roleManager.RoleExistsAsync(StaticEntity.UserRoles.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(StaticEntity.UserRoles.User));
                }

                await _userManager.AddToRoleAsync(user, StaticEntity.UserRoles.User);
            }
            return result;
        }

        public async Task<bool> AssignRoleAsync (User user, string role)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }
    }
}