using DoAnBackend.Models;
using DoAnBackend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet("SearchMedicine")]
        public async Task<IActionResult> SearchMedicine(string searchTerm)
        {
            var medicines = await _medicineService.SearchMedicineAsync(searchTerm);
            if (medicines == null || !medicines.Any())
            {
                return NotFound("Không tìm thấy thuốc");
            }
            return Ok(medicines);
        }
        [HttpPost("AddMedicine")]
        public async Task<IActionResult> AddMedicine(MedicineModel model)
        {
            if (ModelState.IsValid)
            {
                await _medicineService.AddMedicineAsync(model);
                return Ok("Thêm thuốc thành công");
            }
            return BadRequest(ModelState);
        }
        [HttpPut("UpdateMedicine")]
        public async Task<IActionResult> UpdateMedicine(MedicineModel model)
        {
            if (ModelState.IsValid)
            {
                await _medicineService.UpdateMedicineAsync(model);
                return Ok("Cập nhật thành công");
            }
            return BadRequest(ModelState);
        }
    }
}
