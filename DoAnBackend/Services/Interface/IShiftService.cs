using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Services.Interface
{
    public interface IShiftService
    {
        Task<IEnumerable<ShiftModel>> GetShiftsAsync();
        Task<ShiftModel> GetShiftByIdAsync(Guid shiftId);
        Task<Shift> GetShiftByNameAsync(string shiftName);
        Task<ShiftModel> CreateShiftAsync(ShiftModel.CreateShiftModel model);
        Task UpdateShiftAsync(string shiftName, ShiftModel.CreateShiftModel model);
        Task DeleteShiftAsync(string shiftName);
    }
}
