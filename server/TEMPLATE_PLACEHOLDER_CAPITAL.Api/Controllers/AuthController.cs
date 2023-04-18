using System.Threading.Tasks;
using TEMPLATE_PLACEHOLDER_CAPITAL.Api.Extensions;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILoginService _loginService;

        public class LoginVM
        {
            public string User { get; set; }
            public string Password { get; set; }

        }
        public AuthController(
            IAuthService authService,
            ILoginService loginService
        )
        {
            _authService = authService;
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM login, [FromServices] IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development" && login.Password == "pwd")
            {
                login.Password = "secret-password";
            }
            var userId = await _authService.Check(login.User, login.Password);
            if (userId != null)
            {
                await _loginService.SignIn(login.User, userId.Value);
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var user = HttpContext.UserId();
            if (user == null)
            {
                return Unauthorized();
            }
            await _authService.ChangePassword(user.Value, request.CurrentPassword, request.NewPassword);
            return Ok();
        }

        public class ChangePasswordRequest
        {
            public string CurrentPassword { get; set; }
            public string NewPassword { get; set; }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _loginService.SignOut();
            return Ok();
        }

        [HttpGet("whoami")]
        public async Task<IActionResult> WhoAmI()
        {
            var user = await _loginService.CurrentUser;
            if (user != null)
            {
                return Ok(new { user });
            }
            return NotFound();
        }
    }
}