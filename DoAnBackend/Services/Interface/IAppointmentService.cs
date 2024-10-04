using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Services.Interface
{
    public interface IAppointmentService
    {
        Task<AppointmentModel?> GetAppointmentByIdAsync(Guid id);
        Task<List<AppointmentModel>> GetAppointmentsByDateAsync(DateOnly date);
        Task<Appointment> CreateAppointmentAsync(AppointmentModel.CreateAppointmentModel model, string patientId, string patientEmail, string patientName);
        Task ConfirmAppointmentAsync(string name, string nurseEmail);
        Task CancelAppointmentAsync(string name, string patientEmail);
        Task DoctorGetAppointment(string name, string DoctorEmail);
        Task<int> GenerateAppointmentNumber(DateOnly date);
        Task<List<Appointment>> GetAllAsync();
        Task<IEnumerable<Appointment>> GetPatientHistoryAsync(string patientEmail, DateOnly startDate, DateOnly endDate);
        Task<IEnumerable<AppointmentModel>> GetAppointmentsByPatientEmailAsync(string email);
        Task<List<AppointmentModel>> GetAppointmentsByNameContainsAsync(string appointmentName);
        Task<AppointmentModel?> GetByAppointmentNameAsync(string appointmentName);
    }
}
