using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Repositories.Interface
{
    public interface IAppointmentRepository
    {
        Task <Appointment?> GetByIdAsync(Guid id);
        Task <List<Appointment>> GetAppointmentsByDateAsync(DateOnly appointmentDate);
        Task CreateAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task <List<Appointment>> GetAllAsync();
        //Task<List<AppointmentModel>> GetAppointmentsByPatientEmailAsync(string email);
        Task<IEnumerable<Appointment>> GetCompletedAppointmentsAsync(string patientEmail, DateOnly startDate, DateOnly endDate);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientEmailAsync(string email);
    }
}
