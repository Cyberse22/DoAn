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
        [HttpGet("ByDate")]
        public async Task<IActionResult> GetPrescriptionByDate(DateOnly appointmentDate)
        {
            var prescriptions = await _prescriptionService.GetPrescriptionsByDateAsync(appointmentDate);
            return Ok(prescriptions);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePrescription(PrescriptionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _prescriptionService.CreatePrescriptionAsync(model);
            return Ok(model);
        }
    }
}
