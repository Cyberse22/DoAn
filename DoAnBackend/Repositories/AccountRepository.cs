using DoAnBackend.Data;
using DoAnBackend.Helpers;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoAnBackend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public AccountRepository(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext applicationDbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IdentityResult> CreateAdminAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                UserName = model.Email,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
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
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                UserName = model.Email,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(StaticEntity.UserRoles.Patient))
                {
                    await _roleManager.CreateAsync(new IdentityRole(StaticEntity.UserRoles.Patient));
                }

                await _userManager.AddToRoleAsync(user, StaticEntity.UserRoles.Patient);
            }
            return result;
        }

        public async Task<bool> AssignRoleAsync(ApplicationUser user, string role)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            _applicationDbContext.Entry(user).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword)
        {
            var user = await _applicationDbContext.Users.FindAsync(email);
            if (user == null)
            {
                return false;
            }

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, currentPassword);

            if (result == PasswordVerificationResult.Success)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, newPassword);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IdentityResult> CreateUserByAdminAsync(CreateByAdmin model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                UserName = model.Email,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                string role = model.Role switch
                {
                    "Nurse" => StaticEntity.UserRoles.Nurse,
                    "Doctor" => StaticEntity.UserRoles.Doctor,
                    _ => throw new ArgumentException("Invalid role. Must be either 'Nurse' or 'Doctor'.")
                };
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                await _userManager.AddToRoleAsync(user, model.Role);
            }
            return result;
        }

        public async Task<CurrentUserDetailModel> GetUserDetailsByIdAndEmailAsync(string userId, string email)
        {
            var user = await (from u in _applicationDbContext.Users
                            join ur in _applicationDbContext.UserRoles on u.Id equals ur.UserId
                            join r in _applicationDbContext.Roles on ur.RoleId equals r.Id
                            where u.Id == userId && u.Email == email
                            select new  CurrentUserDetailModel
                            {
                                Id = u.Id,
                                Email = u.Email,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                PhoneNumber = u.PhoneNumber,
                                Gender = u.Gender,
                                Role = r.Name
                            }).FirstOrDefaultAsync();
            return user;
        }

        public async Task<CurrentUserDetailModel> GetAppointmentsByPatientEmailAsync(string email)
        {
            var user = await (from u in _applicationDbContext.Users
                              join ur in _applicationDbContext.UserRoles on u.Id equals ur.UserId
                              join r in _applicationDbContext.Roles on ur.RoleId equals r.Id
                              where u.Email == email
                              select new CurrentUserDetailModel
                              {
                                  Id = u.Id,
                                  Email = u.Email,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  PhoneNumber = u.PhoneNumber,
                                  Gender = u.Gender,
                                  Role = r.Name 
                              }).FirstOrDefaultAsync();
            return user;
        }
    }
}