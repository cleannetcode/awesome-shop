using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Accounts.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Api.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _userService.RegisterAsync(request, cancellationToken);

            if (!response.IsSuccess)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginRequest model, CancellationToken cancellationToken = default)
        {
            var response = await _userService.LoginAsync(model, cancellationToken);

            if (!response.IsSuccess)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMe(CancellationToken cancellationToken = default)
        {
            var user = await _userService.GetMeAsync(User, cancellationToken);
            return Ok(user);
        }
    }
}