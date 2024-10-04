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

        public async Task<Prescription> CreatePrescriptionAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }

        public async Task<Prescription> GetPrescriptionByAppointmentName(string appointmentName)
        {
            return await _context.Prescriptions
                                 .Include(p => p.PrescriptionDetails)
                                 .ThenInclude(pd => pd.Medicine)
                                 .FirstOrDefaultAsync(p => p.AppointmentName == appointmentName);
        }

        public async Task UpdatePrescription(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            await _context.SaveChangesAsync();
        }
    }
}
