using DoAnBackend.Models;

namespace DoAnBackend.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<UserDetailModel>> GetAll();
        Task<UserDetailModel> GetById(string id);
        Task Update(UserDetailModel user);
        Task Delete(string id);
        Task<string?> GetUserRole(string id);
    }
}
