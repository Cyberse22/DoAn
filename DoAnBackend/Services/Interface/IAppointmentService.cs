using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Services.Interface
{
    public interface IAppointmentService
    {
        Task<AppointmentModel?> GetAppointmentByIdAsync(Guid id);
        Task<List<AppointmentModel>> GetAppointmentsByDateAsync(DateOnly date);
        Task<Appointment> CreateAppointmentAsync(AppointmentModel.CreateAppointmentModel model, string patientId, string patientEmail, string patientName);
        Task ConfirmAppointmentAsync(Guid id, string nurseId);
        Task CancelAppointmentAsync(Guid id, string userId);
        Task<int> GenerateAppointmentNumber(DateOnly date);
        Task<List<Appointment>> GetAllAsync();
        //Task<List<AppointmentModel>> GetAppointmentsByPatientEmailAsync(string email);
        Task<IEnumerable<Appointment>> GetPatientHistoryAsync(string patientEmail, DateOnly startDate, DateOnly endDate);
        Task<IEnumerable<AppointmentModel>> GetAppointmentsByPatientEmailAsync(string email);

    }
}
