using DoAnBackend.Data;
using DoAnBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DoAnBackend.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly ApplicationDbContext _context;
        public ShiftRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shift> CreateShiftAsync(Shift shift)
        {
            _context.Shifts.Add(shift);
            await _context.SaveChangesAsync();
            return shift;
        }

        public async Task DeleteShiftAsync(string name)
        {
            var shift = await GetShiftByNameAsync(name);
            if (shift != null) { 
                _context.Shifts.Remove(shift);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Shift>> GetAllShiftAsync()
        {
            return await _context.Shifts
                                 .Include(s => s.Nurse)
                                 .Include(s => s.Doctor)
                                 .ToListAsync();
        }

        public async Task<Shift> GetShiftByIdAsync(Guid id)
        {
            return await _context.Shifts
                                 .Include(s => s.Nurse)
                                 .Include(s => s.Doctor)
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Shift> GetShiftByNameAsync(string name)
        {
            return await _context.Shifts
                                 .FirstOrDefaultAsync(s => s.ShiftName == name);
        }

        public async Task UpdateShiftAsync(Shift shift)
        {
            _context.Shifts.Update(shift);
            await _context.SaveChangesAsync();
        }
    }
}
