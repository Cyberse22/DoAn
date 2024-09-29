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
        private readonly IAccountRepository _accountRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, IAccountRepository accountRepository)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task CancelAppointmentAsync(Guid id, string userId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException("Appointment not found");

            if (appointment.PatientId != userId)
                throw new UnauthorizedAccessException("You are not authorized to cancel this appointment.");

            appointment.Status = "Cancelled";

            await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        public async Task ConfirmAppointmentAsync(Guid id, string nurseId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException("Appointment not found");

            // Cập nhật trạng thái và thông tin Nurse
            appointment.Status = "Confirmed";
            appointment.NurseId = nurseId;

            await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        public async Task<Appointment> CreateAppointmentAsync(AppointmentModel.CreateAppointmentModel model, string patientId)
        {
            var appointment = _mapper.Map<Appointment>(model);
            appointment.PatientId = patientId;
            appointment.Status = "Pending";
            appointment.Number = await GenerateAppointmentNumber(model.AppointmentDate);

            await _appointmentRepository.CreateAppointmentAsync(appointment);
            return appointment;
        }

        public async Task<int> GenerateAppointmentNumber(DateOnly date)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDateAsync(date);
            if (appointments.Count >= 100)
            {
                throw new InvalidOperationException("The clinic has reached the daily appointment limit.");
            }
            return appointments.Count + 1;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<AppointmentModel?> GetAppointmentByIdAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null) return null;

            return _mapper.Map<AppointmentModel>(appointment);
        }

        public async Task<List<AppointmentModel>> GetAppointmentsByDateAsync(DateOnly date)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDateAsync(date);

            return _mapper.Map<List<AppointmentModel>>(appointments);
        }

        public async Task<List<AppointmentModel>> GetAppointmentsByPatientEmailAsync(string email)
        {
            var patient = await _accountRepository.GetUserByEmailAsync(email);
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }
            return await _appointmentRepository.GetAppointmentsByPatientEmailAsync(email);
        }

        public async Task<IEnumerable<Appointment>> GetPatientHistoryAsync(string patientEmail, DateOnly startDate, DateOnly endDate)
        {
            return await _appointmentRepository.GetCompletedAppointmentsAsync(patientEmail, startDate, endDate);
        }
    }
}
