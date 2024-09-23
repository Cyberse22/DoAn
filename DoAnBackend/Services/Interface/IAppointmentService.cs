using DoAnBackend.Models;
using System.Security.Claims;

namespace DoAnBackend.Services.Interface
{
    public interface IAppointmentService
    {
        Task<AppointmentModel> CreateAppointment(AppointmentModel model, ClaimsPrincipal user);
        Task<AppointmentModel> UpdateAppointment(string appointmentId);
        Task<AppointmentModel> ConfirmAppointment(string appointmentId, string NurseId);
        Task<IEnumerable<AppointmentModel.AppointmentDetails>> GetAllAppointments(); 

    }
}
