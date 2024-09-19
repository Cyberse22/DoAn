using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using DoAnBackend.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoAnBackend.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> SignInAsync(SignInModel model)
        {
            var result = await _accountRepository.SignInAsync(model.Email, model.Password);
            if (!result.Succeeded)
            {
                return string.Empty;
            }

            var token = GenerateJwtToken(model.Email);
            return token;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            return await _accountRepository.SignUpAsync(model);
        }

        private string GenerateJwtToken(string email)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> CreateAdminAsync(SignUpModel model)
        {
            var result = await SignUpAsync(model);
            if (!result.Succeeded)
            {
                return result;
            }

            // Lấy User vừa tạo để làm Admin
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            // Gán role Admin cho User
            var roleResult = await AssignRoleAsync(user, "Admin");
            if (!roleResult)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Failed to assign Admin role." });
            }

            return IdentityResult.Success;
        }    

        public async Task<bool> AssignRoleAsync(User user, string role)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists) 
            {
                // Tạo mới role nếu chưa tồn tại
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

            // Gán Role cho User
            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }
    }
}