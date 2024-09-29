using DoAnBackend.Data;
using DoAnBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DoAnBackend.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ApplicationDbContext _context;
        public PrescriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPrescriptionAsync(Prescription prescription)
        {
            await _context.Prescriptions.AddAsync(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByDateAsync(DateOnly appointmentDate)
        {
            return await _context.Prescriptions
                                 .Include(p => p.Patient)
                                 .Include(p => p.Doctor)
                                 .Include(p => p.PrescriptionDetails)
                                 .ThenInclude(pd => pd.Medicine)
                                 .Where(p => p.Appointment.AppointmentDate == appointmentDate)
                                 .ToListAsync(); 
        }
    }
}
