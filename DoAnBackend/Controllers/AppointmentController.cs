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
    [Route("api/[controller]")]
    [ApiController]
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
            var email = User.FindFirstValue(ClaimTypes.Email);
            var name = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found.");
            }

            await _appointmentService.CreateAppointmentAsync(model, userId, email, name);
            return Ok("Appointment created successfully.");
        }

        [HttpPut("Cancel")]
        //[Authorize(Roles = "Patient")]
        public async Task<IActionResult> CancelAppointment(string name)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _appointmentService.CancelAppointmentAsync(name, email);
            return Ok("Appointment cancelled successfully.");
        }
        [HttpPut("Confirm")]
        //[Authorize(Roles = "Nurse")]
        public async Task<IActionResult> ConfirmAppointment(string name)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _appointmentService.ConfirmAppointmentAsync(name, email);
            return Ok("Appointment confirmed successfully.");
        }
        [HttpPut("ExaminatingInProgress")]
        public async Task<IActionResult> DoctorGetAppointment(string name)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _appointmentService.DoctorGetAppointment(name, email);
            return Ok("Doctor has get Appointment");
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
        [HttpGet("ByPatientEmail")]
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
        [HttpGet("SearchByName")]
        public async Task<IActionResult> GetAppointmentsByNameContains(string appointmentName)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentsByNameContainsAsync(appointmentName);
                if (appointments == null || !appointments.Any())
                {
                    return NotFound("No appointments found with the given " + appointmentName);
                }

                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByAppointmentName(string appointmentName)
        {
            try
            {
                var appointment = await _appointmentService.GetByAppointmentNameAsync(appointmentName);
                if (appointment == null)
                {
                    return NotFound("Appointment not found");
                }

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
