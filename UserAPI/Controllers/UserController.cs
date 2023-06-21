using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.DTOs;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private RegisterService _registerService;

        public UserController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserDTO createUserDTO)
        {
            await _registerService.Register(createUserDTO);

            return Ok("User created successfully");
        }
    }
}