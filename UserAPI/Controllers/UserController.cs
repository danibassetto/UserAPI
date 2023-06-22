using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.DTOs;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(CreateUserDTO createUserDTO)
        {
            await _userService.Register(createUserDTO);

            return Ok("User created successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
           var token = await _userService.Login(loginUserDTO);
           return Ok($"Authenticated user: {token}");
        }
    }
}