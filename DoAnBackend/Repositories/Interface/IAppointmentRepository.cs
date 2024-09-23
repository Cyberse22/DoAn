using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Repositories.Interface
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(string id);
        Task<IEnumerable<Appointment>> GetAll();
        Task CreateAppointmentAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(string id);
    }
}
