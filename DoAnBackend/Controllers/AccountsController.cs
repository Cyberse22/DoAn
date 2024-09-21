using DoAnBackend.Models;
using DoAnBackend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace DoAnBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountsController(IAccountService service, IHttpContextAccessor httpContextAccessor)
        {
            _accountService = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await _accountService.SignUpAsync(signUpModel);
            if (result.Succeeded) 
            {
                return Ok(result.Succeeded);
            }

            return StatusCode(500);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            var result = await _accountService.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin([FromBody] SignUpModel model)
        {
            var result = await _accountService.CreateAdminAsync(model);
            if (result.Succeeded)
            {
                return Ok("Admin created successfully");
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(PasswordModel passwordModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.ChangePasswordAsync(passwordModel);
            if (result)
            {
                return Ok(new { message = "Paasword changed successfully" });
            }
            return BadRequest(new { message = "Failed to change password" });
        }
    }
}
