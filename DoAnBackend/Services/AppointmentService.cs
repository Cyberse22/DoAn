using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Helpers;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using DoAnBackend.Services.Interface;
using System.Globalization;
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

        public async Task CancelAppointmentAsync(string name, string patientEmail)
        {
            var appointment = await _appointmentRepository.GetByAppointmentNameDetailsAsync(name);
            if (appointment == null)
                throw new KeyNotFoundException("Appointment not found");

            if (appointment.PatientEmail != patientEmail)
                throw new UnauthorizedAccessException("You are not authorized to cancel this appointment.");
            appointment.Status = "Cancelled";
            await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        public async Task ConfirmAppointmentAsync(string name, string nurseEmail)
        {
            var appointment = await _appointmentRepository.GetByAppointmentNameDetailsAsync(name);
            if (appointment == null)
                throw new KeyNotFoundException("Appointment not found");
            var nurse = await _accountRepository.GetCurrentUserByEmailAsync2(nurseEmail);
            // Cập nhật trạng thái và thông tin Nurse
            appointment.Status = "Confirmed";
            appointment.NurseId = nurse.Id;
            appointment.NurseEmail = nurseEmail;
            appointment.NurseName = $"{nurse.FirstName} {nurse.LastName}";

            await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }
        public async Task DoctorGetAppointment(string name, string doctorEmail)
        {
            var appointment = await _appointmentRepository.GetByAppointmentNameDetailsAsync(name);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found");
            var doctor = await _accountRepository.GetCurrentUserByEmailAsync2(doctorEmail);
            appointment.Status = StaticEntity.Status.ExaminationInProgress;
            appointment.DoctorEmail = doctorEmail;
            appointment.DoctorId = doctor.Id;
            appointment.DoctorName = $"{doctor.FirstName} {doctor.LastName}";

            await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        public async Task<Appointment> CreateAppointmentAsync(AppointmentModel.CreateAppointmentModel model, string patientId, string patientEmail, string patientName)
        {
            var patient = await _accountRepository.GetUserByEmailAsync(patientEmail);
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }
            
            var appointment = _mapper.Map<Appointment>(model);
            appointment.PatientId = patientId;
            appointment.PatientEmail = patientEmail;
            appointment.PatientName = $"{patient.FirstName} {patient.LastName}";
            appointment.Status = "Pending";
            appointment.AppointmentDate = model.AppointmentDate;
            appointment.Number = await GenerateAppointmentNumber(model.AppointmentDate);
            var emailPatient = patientEmail.Split('@')[0];
            var formattedDate = appointment.AppointmentDate.ToString("ddMMyyyy");
            appointment.AppointmentName = $"p{emailPatient}d{formattedDate}";
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

        public async Task<List<AppointmentModel>> GetAppointmentsByNameContainsAsync(string appointmentName)
        {
            var appointments = await _appointmentRepository.GetByAppointmentNameContainsAsync(appointmentName);
            var appointmentModels = _mapper.Map<List<AppointmentModel>>(appointments);
            return appointmentModels;
        }

        public async Task<IEnumerable<AppointmentModel>> GetAppointmentsByPatientEmailAsync(string email)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByPatientEmailAsync(email);
            return _mapper.Map<IEnumerable<AppointmentModel>>(appointments);
        }

        public async Task<AppointmentModel?> GetByAppointmentNameAsync(string appointmentName)
        {
            var appointment = await _appointmentRepository.GetByAppointmentNameDetailsAsync(appointmentName);
            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }
            var appointmentModel = _mapper.Map<AppointmentModel>(appointment);
            return appointmentModel;
        }

        public async Task<IEnumerable<Appointment>> GetPatientHistoryAsync(string patientEmail, DateOnly startDate, DateOnly endDate)
        {
            return await _appointmentRepository.GetCompletedAppointmentsAsync(patientEmail, startDate, endDate);
        }

        public async Task<List<Appointment>> GetAppointmentsByStatus(string status)
        {
            return await _appointmentRepository.GetAppointmentsByStatusAsync(status);
        }
    }
}
