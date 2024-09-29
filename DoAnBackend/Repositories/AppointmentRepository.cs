using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DoAnBackend.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByDateAsync(DateOnly appointmentDate)
        {
            return await _context.Appointments
                                 .Where(a => a.AppointmentDate == appointmentDate)
                                 .ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            return await _context.Appointments
                                 .Include(a => a.Patient)  // Bao gồm các quan hệ nếu cần
                                 .Include(a => a.Nurse)
                                 .Include(a => a.Doctor)
                                 .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAllAsync() 
        { 
            return await _context.Appointments.ToListAsync();
        }

        public async Task<List<AppointmentModel>> GetAppointmentsByPatientEmailAsync(string email)
        {
            var appointments = await _context.Appointments
                                             .Where(a => a.Patient.Email == email)
                                             .Select(a => new AppointmentModel
                                             {
                                                 Id = a.Id,
                                                 Reason = a.Reason,
                                                 AppointmentDate = a.AppointmentDate,
                                                 Status = a.Status,
                                             }).ToListAsync();
            return appointments;
        }

        public async Task<IEnumerable<Appointment>> GetCompletedAppointmentsAsync(string patientEmail, DateOnly startDate, DateOnly endDate)
        {
            return await _context.Appointments
                                 .Where(a => a.Patient.Email == patientEmail &&
                                             a.Status == "Complete" &&
                                             a.AppointmentDate >= startDate &&
                                             a.AppointmentDate <= endDate)
                                 .Include(a => a.Doctor)
                                 .Include(a => a.Prescription)
                                 .ToListAsync();
        }
    }
}
