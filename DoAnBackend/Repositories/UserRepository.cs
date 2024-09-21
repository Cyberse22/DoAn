using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using Microsoft.AspNetCore.Identity;

namespace DoAnBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository (ApplicationDbContext applicationDbContext, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDetailModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDetailModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetUserRole(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDetailModel model)
        {
            throw new NotImplementedException();
        }
    }
}
