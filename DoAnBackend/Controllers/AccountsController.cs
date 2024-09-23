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
using System.Security.Claims;

namespace DoAnBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        

        public AccountsController(IAccountService service, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _accountService = service;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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

        //[Authorize]
        //[HttpGet("GetCurrentUser")]
        //public async Task<ActionResult<CurrentUserModel>> GetCurrentUser() 
        //{
        //    var email = User.FindFirst(ClaimTypes.Email)?.Value;

        //    if (string.IsNullOrEmpty(email))
        //    {
        //        return NotFound(email); 
        //    }

        //    var userId = await _accountService.GetUserByEmailAsync(email);

        //    var currentUser = new CurrentUserModel
        //    {
        //        Id = userId,
        //        Email = email
        //    };
        //    currentUser.Email = email;
        //    currentUser.Id = userId;
        //    return Ok(currentUser);
        //}

        //private async Task<CurrentUserModel> CreateCurrentUserModel()
        //{
        //    var email = User.FindFirst(ClaimTypes.Email)?.Value;

        //    if (string.IsNullOrEmpty(email))
        //    {
        //        throw new InvalidOperationException("Không tìm thấy email trong claims."); // Ném exception nếu không tìm thấy email
        //    }

        //    var userId = await _accountService.GetUserByEmailAsync(email);

        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        throw new InvalidOperationException("Người dùng không tìm thấy."); // Ném exception nếu không tìm thấy người dùng
        //    }

        //    return new CurrentUserModel
        //    {
        //        Id = userId,
        //        Email = email
        //    };
        //}

        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentUser = await Helper.CreateCurrentUserModel(_accountService, User);

            if (currentUser == null)
            {
                return NotFound("Người dùng không tìm thấy.");
            }

            return Ok(currentUser);
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
