using DoAnBackend.Data;

namespace DoAnBackend.Repositories.Interface
{
    public interface IShiftRepository
    {
        Task<IEnumerable<Shift>> GetAllShiftAsync();
        Task<Shift> GetShiftByNameAsync(string name);
        Task<Shift> CreateShiftAsync(Shift shift);
        Task UpdateShiftAsync(Shift shift);
        Task DeleteShiftAsync(string name);
        Task<Shift> GetShiftByIdAsync(Guid id);
    }
}
