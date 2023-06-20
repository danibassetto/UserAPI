using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.DTOs;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult RegisterUser(CreateUserDTO createUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}