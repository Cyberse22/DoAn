using DoAnBackend.Data;
using DoAnBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DoAnBackend.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDbContext _context;
        public MedicineRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task AddMedicineAsync(Medicine medicine)
        {
            await _context.Medicines.AddAsync(medicine);
            await _context.SaveChangesAsync();
        }

        public async Task<Medicine> GetMedicineAsync(string medicineId)
        {
            return await _context.Medicines.FirstOrDefaultAsync(m => m.MedicineId == medicineId);
        }

        public async Task<IEnumerable<Medicine>> SearchMedicineAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Medicines.ToListAsync();
            }
            var lowerSearchTerm = searchTerm.ToLower();
            return await _context.Medicines
                                 .Where(m => m.Name != null && m.Name.ToLower().Contains(lowerSearchTerm))
                                 .ToListAsync();
        }

        public async Task UpdateMedicineAsync(Medicine medicine)
        {
            var exists = await _context.Medicines.FindAsync(medicine.Name);
            if (exists != null)
            {
                exists.Name = medicine.Name;
                exists.Unit = medicine.Unit;
                exists.Price = medicine.Price;
                
                _context.Medicines.Update(exists);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
