using DoAnBackend.Models;
using DoAnBackend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresciptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        public PresciptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }
        [HttpGet("{appointmentName}")]
        public async Task<IActionResult> GetPrescription(string appointmentName)
        {
            var prescription = await _prescriptionService.GetPrescriptionByAppointmentName(appointmentName);
            if (prescription == null)
            {
                return NotFound();
            }
            return Ok(prescription);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePrescription(PrescriptionModel.CreatePrescription model, string appointmentName)
        {
            var prescription = await _prescriptionService.CreatePrescriptionAsync(model, appointmentName);
            return Ok(prescription);
        }

        [HttpPut("{appointmentName}")]
        public async Task<IActionResult> UpdatePrescription(string appointmentName, [FromBody] PrescriptionModel prescriptionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _prescriptionService.UpdatePrescription(prescriptionModel);
            return NoContent();
        }
    }
}
