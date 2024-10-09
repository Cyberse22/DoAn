using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoAnBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresciptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IAppointmentService _appointmentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountService _accountService;
        public PresciptionController(IPrescriptionService prescriptionService, IAppointmentService appointmentService, IAccountService accountService, UserManager<ApplicationUser> userManager)
        {
            _prescriptionService = prescriptionService;
            _appointmentService = appointmentService;
            _accountService = accountService;
            _userManager = userManager;
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
        [HttpPost("Create")]
        public async Task<IActionResult> CreatePrescription(PrescriptionModel.CreatePrescription model, string appointmentName)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _appointmentService.DoctorGetAppointment(appointmentName, email);

            var prescription = await _prescriptionService.CreatePrescriptionAsync(model, appointmentName);
            return Ok(prescription);
        }
        [HttpPost("Add-Medicines")]
        public async Task<IActionResult> AddMedicinesToPrescription(PrescriptionModel.CreatePrescriptionDetails createPrescription)
        {
            await _prescriptionService.AddMedicineToPrescriptionDetailsAsync(createPrescription.PrescriptionName, new List<PrescriptionModel.CreatePrescriptionDetails> { createPrescription });
            return Ok();
        }

        [HttpPost("Add-Medicines-List")]
        public async Task<IActionResult> AddMedicinesListToPrescription(List<PrescriptionModel.CreatePrescriptionDetails> createPrescriptionDetails)
        {
            if (createPrescriptionDetails.Count > 0)
            {
                var prescriptionName = createPrescriptionDetails.First().PrescriptionName;
                await _prescriptionService.AddMedicineToPrescriptionDetailsAsync(prescriptionName, createPrescriptionDetails);
                return Ok();
            }
            return BadRequest("List is Empty");
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
