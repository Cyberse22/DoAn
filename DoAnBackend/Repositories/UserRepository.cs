using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoAnBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _mapper = mapper;
        }
        public async Task Delete(string id)
        {
            var user = await _context.ApplicationUsers.SingleOrDefaultAsync(x => x.Id == id);
            if (user != null) 
            { 
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserDetailModel>> GetAll()
        {
            var users = await _context.ApplicationUsers.ToListAsync();
            var userModels = new List<UserDetailModel>();

            foreach (var user in users) 
            {
                userModels.Add(new UserDetailModel 
                {   Id = user.Id, 
                    UserName = user.UserName, 
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Role = await GetUserRole(user.Id)
                });
            }
            return userModels;
        }

        public async Task<UserDetailModel> GetById(string id)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) 
            {
                return null!;
            }
            var role = await GetUserRole(user.Id);
            var userModel = _mapper.Map<UserDetailModel>(user);
            userModel.Role = role;
            return userModel;
        }

        public async Task<string?> GetUserRole(string id)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (currentUser == null) 
            {
                return null!;
            }
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == currentUser.Id);
            if (userRole == null) 
            {
                return null;
            }
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == userRole.RoleId);
            if (role == null)
            {
                return null;
            }
            return role.Name;
        }

        public async Task Update(UserDetailModel userDetail)
        {
            var user = _context.ApplicationUsers.SingleOrDefault(x => x.Id == userDetail.Id);
            if (user!= null)
            {
                _mapper.Map(user, userDetail);
                if (!string.IsNullOrEmpty(userDetail.Password))
                {
                    var passwordHasher = new PasswordHasher<ApplicationUser>();
                    user.PasswordHash = passwordHasher.HashPassword(user, userDetail.Password);
                }

                if (!await _roleManager.RoleExistsAsync(userDetail.Role)) 
                {
                    await _roleManager.CreateAsync(new IdentityRole(userDetail.Role));
                }
                var currentRoles = await _userManager.GetRolesAsync(user);
                if (currentRoles.Count > 0)
                {
                    await _userManager.RemoveFromRolesAsync(user, currentRoles);
                }
                await _userManager.AddToRoleAsync(user, userDetail.Role);
                await _context.SaveChangesAsync();

            }
        }
    }
}
