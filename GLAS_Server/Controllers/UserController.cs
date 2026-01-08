using Microsoft.AspNetCore.Mvc;
using GLAS_Server.DTO;
using GLAS_Server.Services.Interfaces;

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
        public async Task<IActionResult> GetProfile(uint id)
        {
            var profile = await _userService.GetProfileAsync(id);

            if (profile == null) return NotFound("User not found");

            return Ok(profile);


        }

        //api/user/register(JSON body)

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginRequest loginRequestJSON)
        {
            var result = await _userService.LoginAsync(loginRequestJSON);

            if (!result.Success) return NotFound(result.Message);

            return Ok(result.Message);
        }

        //api/user/register(JSON body)

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterRequest registerRequestJSON)
        {
            var result = await _userService.RegisterAsync(registerRequestJSON);

            if (!result.Success) return NotFound(result.Message);

            return Ok(result.Message);


        }
        //[HttpPost("update")]
        //public async Task<IActionResult> UpdateUserData()
    }


}
