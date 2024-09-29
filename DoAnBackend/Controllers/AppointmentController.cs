using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoAnBackend.Controllers
{
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "Patient")]
        public async Task<IActionResult> CreateAppointment(AppointmentModel.CreateAppointmentModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found.");
            }

            await _appointmentService.CreateAppointmentAsync(model, userId);
            return Ok("Appointment created successfully.");
        }

        [HttpPost("Cancel/{id}")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> CancelAppointment(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _appointmentService.CancelAppointmentAsync(id, userId);
            return Ok("Appointment cancelled successfully.");
        }

        [HttpPost("Confirm/{id}")]
        [Authorize(Roles = "Nurse")]
        public async Task<IActionResult> ConfirmAppointment(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _appointmentService.ConfirmAppointmentAsync(id, userId);
            return Ok("Appointment confirmed successfully.");
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor, Nurse, Admin")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound("Appointment not found.");

            return Ok(appointment);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _appointmentService.GetAllAsync();
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound("No appointments found.");
            }
            return Ok(appointments);
        }
        //[HttpGet("GetByPatient/{patientId}")]
        //public async Task<IActionResult> GetAppointmentsByPatientId(string Email)
        //{
        //    var user = User.FindFirstValue(ClaimTypes.Email);
        //    if (user == null) return NotFound();
        //    var patientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(patientId);
        //    if (appointments == null || appointments.Count == 0)
        //    {
        //        return NotFound($"No appointments found for patient with ID {patientId}.");
        //    }
        //    return Ok(appointments);
        //}
        [HttpGet("ByPatientEmail/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatientEmail(string email)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentsByPatientEmailAsync(email);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("ByDate")]
        public async Task<IActionResult> GetAppointmentsByDate(DateOnly appointmentDate)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentsByDateAsync(appointmentDate);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("GetPatientHistory")]
        public async Task<IActionResult> GetPatientHistory(string patientEmail, DateOnly startDate, DateOnly endDate)
        {
            var appointments = await _appointmentService.GetPatientHistoryAsync(patientEmail, startDate, endDate);
            if (appointments == null || !appointments.Any())
            {
                return NotFound("No appointment history found.");
            }
            return Ok(appointments);
        }
    }
}
