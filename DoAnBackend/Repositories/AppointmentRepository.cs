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
            var appointments = await _context.Appointments
                                 .Where(a => a.AppointmentDate == appointmentDate)
                                 .Include(a => a.Patient)
                                 .ToListAsync();
            foreach (var appointment in appointments)
            {
                if (appointment.Patient != null) // Kiểm tra Patient không null
                {
                    appointment.PatientName = $"{appointment.Patient.LastName} {appointment.Patient.FirstName}";
                }
            }

            return appointments;
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

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientEmailAsync(string email)
        {
            return await _context.Appointments
                .Where(a => a.PatientEmail == email)
                .ToListAsync();
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

        public async Task<List<Appointment>> GetByAppointmentNameContainsAsync(string appointmentName)
        {
            return await _context.Appointments
                                 .Where(a => a.AppointmentName.Contains(appointmentName))
                                 .ToListAsync();
        }

        public async Task<Appointment?> GetByAppointmentNameDetailsAsync(string appointmentName)
        {
            return await _context.Appointments
                                 .FirstOrDefaultAsync(a => a.AppointmentName == appointmentName);
        }

        public async Task<List<Appointment>> GetAppointmentsByStatusAsync(string status)
        {
            return await _context.Appointments
                                 .Where (a => a.Status == status)
                                 .ToListAsync();
        }
    }
}
