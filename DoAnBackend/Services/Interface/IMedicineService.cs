using DoAnBackend.Models;

namespace DoAnBackend.Services.Interface
{
    public interface IMedicineService
    {
        Task<IEnumerable<MedicineModel>> SearchMedicineAsync(string searchTerm);
        Task AddMedicineAsync(MedicineModel model);
        Task UpdateMedicineAsync(MedicineModel model);
    }
}
