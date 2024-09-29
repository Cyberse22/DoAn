

using DoAnBackend.Data;

namespace DoAnBackend.Repositories.Interface
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> SearchMedicineAsync(string searchTerm);
        Task AddMedicineAsync(Medicine medicine);
        Task UpdateMedicineAsync(Medicine medicine);
    }
}
