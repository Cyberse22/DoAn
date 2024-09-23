using DoAnBackend.Models;
using DoAnBackend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController (IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<AppointmentModel>> CreateAppointment(AppointmentModel model)
        {            
            var appointment = await _appointmentService.CreateAppointment(model, User);
            return CreatedAtAction(nameof(CreateAppointment), new { id = appointment.Id });
        }
        [HttpDelete("{appointmentId}")]
        public async Task<ActionResult<AppointmentModel>> Cancel (string appointmentId)
        {
            var appointment = await _appointmentService.UpdateAppointment(appointmentId);
            return Ok(appointment);
        }
        [HttpPut("{appointmentId}/confirm")]
        public async Task<ActionResult<AppointmentModel>> Confirm(string appointmentId, string nurseId)
        {
            var appointment = await _appointmentService.ConfirmAppointment(appointmentId, nurseId);
            return Ok(appointment);
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<AppointmentModel.AppointmentDetails>>> GetAll()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }
    }
}
