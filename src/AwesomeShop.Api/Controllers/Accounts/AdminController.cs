using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Accounts.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Api.Controllers
{
    [ApiController]
    [Route("api/v1/admin")]
    public class AdminController : ControllerBase
    {
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromServices] IUserService service, CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            var result = await service.RegisterAsync(request, request.RoleId, cancellationToken);
            if (!result.IsSuccess)
                return BadRequest();
            return Ok(request);
        }

        [HttpPost("lockout/{userId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Lockout([FromServices] IAdminService service, Guid userId, [FromQuery][Required] TimeSpan time,
            CancellationToken cancellationToken)
        {
            if (time <= TimeSpan.Zero)
                return BadRequest();
            await service.LockoutUserAsync(userId, time, cancellationToken);
            return NoContent();
        }

        [HttpPost("revoke-lockout/{userId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RevokeLockout([FromServices] IAdminService service, Guid userId,
            CancellationToken cancellationToken)
        {
            await service.RevokeLockoutUserAsync(userId, cancellationToken);
            return NoContent();
        }
    }
}