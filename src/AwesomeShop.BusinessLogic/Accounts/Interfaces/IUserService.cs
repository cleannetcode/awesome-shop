using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Requests;
using AwesomeShop.Data.Models;

namespace AwesomeShop.BusinessLogic.Accounts.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse> RegisterAsync(RegisterRequest model, Guid roleId,CancellationToken cancellationToken = default);

        Task<AuthenticationResponse> LoginAsync(LoginRequest model, CancellationToken cancellationToken = default);

        Task<User> GetMeAsync(ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken = default);
    }
}