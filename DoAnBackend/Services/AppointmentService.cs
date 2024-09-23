using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using DoAnBackend.Services.Interface;
using System.Security.Claims;

namespace DoAnBackend.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, IAccountService accountService)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<AppointmentModel> ConfirmAppointment(string appointmentId, string NurseId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (appointment == null) throw new Exception("Appointment not found");
            appointment.Status = "Confirm";
            appointment.NurseId = NurseId;
            await _appointmentRepository.UpdateAsync(appointment);
            return _mapper.Map<AppointmentModel>(appointment);
        }

        public async Task<AppointmentModel> CreateAppointment(AppointmentModel model, ClaimsPrincipal user)
        {
            var currentUser = await Helpers.Helper.CreateCurrentUserModel(_accountService, user);

            var appointment = new Appointment
            {
                Date = DateOnly.FromDateTime(model.Date.Value),
                Time = model.TimeSpan.Value,
                Reason = model.Reason,
                Status = "Pending",
                PatientId = currentUser.Id
            };
            await _appointmentRepository.CreateAppointmentAsync(appointment);
            return _mapper.Map<AppointmentModel>(appointment);
        }

        public async Task<IEnumerable<AppointmentModel.AppointmentDetails>> GetAllAppointments()
        {
            var appointments = await _appointmentRepository.GetAll();
            return _mapper.Map<IEnumerable<AppointmentModel.AppointmentDetails>>(appointments);
        }

        public async Task<AppointmentModel> UpdateAppointment(string appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (appointment == null) throw new Exception("Appointment not found");
            appointment.Status = "Cancelled";
            await _appointmentRepository.UpdateAsync(appointment);
            return _mapper.Map<AppointmentModel>(appointment);
        }
    }
}
