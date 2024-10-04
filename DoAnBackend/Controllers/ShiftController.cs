using DoAnBackend.Models;
using DoAnBackend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShifts()
        {
            var shifts = await _shiftService.GetShiftsAsync();
            return Ok(shifts);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetShiftByName(string name)
        {
            var shift = await _shiftService.GetShiftByNameAsync(name);
            if (shift != null)
            {
                return Ok(shift);
            }
            return NotFound("Shift not found");
        }
        [HttpPost]
        public async Task<IActionResult> CreateShift(ShiftModel.CreateShiftModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var shift = await _shiftService.CreateShiftAsync(model);
            return Ok(shift);
        }
        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateShift(string name, ShiftModel.CreateShiftModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _shiftService.UpdateShiftAsync(name, model);
            return NoContent();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteShift(string name)
        {
            await _shiftService.DeleteShiftAsync(name);
            return NoContent();
        }
    }
}
