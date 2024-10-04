using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Helpers;
using DoAnBackend.Models;
using DoAnBackend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DoAnBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService service, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _accountService = service;
            _userManager = userManager;
            _mapper = mapper;
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

        //[Authorize(Roles = "Admin")]
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

        [HttpPost("CreateByAdmin")]
        public async Task<IActionResult> CreateUserByAdmin([FromBody] CreateByAdmin model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.CreateUserByAdminAsync(model);
            if (result.Succeeded)
            {
                return Ok("User created successfully.");
            }

            return BadRequest(result.Errors);
        }

        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email); // Retrieve email from JWT token
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized("User email not found.");
            }

            var user = await _accountService.GetCurrentUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        [Authorize]
        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _accountService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound("Not have Email");
            }
            var userEmail = await _userManager.FindByEmailAsync(email);
            var getUser = new
            {   
                userEmail.Id,
                userEmail.Email,
                userEmail.FirstName,
                userEmail.LastName,
                userEmail.PhoneNumber
            };
            return Ok(getUser);
        }

        [Authorize]
        [HttpPut("ChangePassword")]
        public async Task<ActionResult<PasswordModel>> ChangePassword(PasswordModel model) 
        {
            if (model == null)
            {
                return BadRequest("Mẫu không hợp lệ.");
            }

            var currentUser = await Helper.CreateCurrentUserModel(_accountService, User);

            if (currentUser == null)
            {
                return Unauthorized();
            }

            var userId = currentUser.Id;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var result = await _accountService.ChangePasswordAsync(userId, model.CurrentPassword, model.NewPassword);
            if (!result)
            {
                return BadRequest("Mật khẩu hiện tại không đúng hoặc có lỗi xảy ra.");
            }

            return Ok("Mật khẩu đã được thay đổi thành công.");
        }
    }
}
