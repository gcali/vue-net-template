using System.Threading.Tasks;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var newId = await _userService.CreateUser(request.Username, request.Password);
            return Ok(new { id = newId });
        }

        public class CreateUserRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}