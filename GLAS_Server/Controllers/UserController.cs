using Microsoft.AspNetCore.Mvc;
using GLAS_Server.DTO;
using GLAS_Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace GLAS_Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) // Сюда DI передает экземпляр класса UserService (interface = class), далее конструктор
        {
            _userService = userService;
        }

        // api/user/profile/{username}

        [HttpGet("profile/{id}")]
        [Authorize]  // Требует JWT токен
        public async Task<IActionResult> GetProfile(uint id)
        {
            var profile = await _userService.GetProfileAsync(id);

            if (profile == null) return NotFound("User not found");

            return Ok(profile);


        }

        //api/user/register(JSON body)

        [HttpPost("login")]
        [AllowAnonymous]  // Разрешаем доступ без токена для логина
        public async Task<IActionResult> LoginUser(LoginRequest loginRequestJSON)
        {
            var result = await _userService.LoginAsync(loginRequestJSON);

            if (result == null) return Unauthorized("Invalid credentials");

            return Ok(result);
        }

        //api/user/register(JSON body)

        [HttpPost("register")]
        [AllowAnonymous]  // Разрешаем регистрацию без токена
        public async Task<IActionResult> RegisterUser(RegisterRequest registerRequestJSON)
        {
            var result = await _userService.RegisterAsync(registerRequestJSON);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Message);


        }
        //[HttpPost("update")]
        //public async Task<IActionResult> UpdateUserData()

        /// <summary>
        /// Запрашивает отправку кода восстановления пароля на номер телефона
        /// </summary>
        [HttpPost("request-password-reset")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestPasswordReset(ResetPasswordViaSmsRequest request)
        {
            var result = await _userService.RequestPasswordResetAsync(request.PhoneNumber);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Message);
        }

        /// <summary>
        /// Проверяет код восстановления пароля и меняет пароль
        /// </summary>
        [HttpPost("verify-password-reset")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyPasswordReset(VerifyPasswordResetCodeRequest request)
        {
            var result = await _userService.VerifyAndResetPasswordAsync(request);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }


}
