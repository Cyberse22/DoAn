using DoAnBackend.Models;

namespace DoAnBackend.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<UserDetailModel>> GetAll();
        Task<UserDetailModel> GetById(int id);
        Task Update(UserDetailModel model);
        Task DeleteById(int id);
        Task <string?> GetUserRole(int id);
    }
}
