using System;
using System.Buffers.Text;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Accounts.Requests;

namespace AwesomeShop.BusinessLogic.Accounts.Services
{
    public class UserService : IUserService
    {
        private readonly IUserCommonRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IHasher _hasher;

        public UserService(IUserCommonRepository repository, ITokenService tokenService, IHasher hasher)
        {
            _repository = repository;
            _tokenService = tokenService;
            _hasher = hasher;
        }

        public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var duplicate = await _repository.GetUserByNameAsync(request.Username, cancellationToken);
            if (duplicate is not null)
                return new() { IsSuccess = false };
            var user = new User
            {
                Username = request.Username
            };
            user.PasswordHash = _hasher.HashPassword(user, request.Password);
            await _repository.CreateUserAsync(user, cancellationToken);
            return await _tokenService.CreateAuthenticationResponseAsync(user, cancellationToken);
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginRequest model, CancellationToken cancellationToken = default)
        {
            var user = await _repository.GetUserByNameAsync(model.Username, cancellationToken);
            var hash = _hasher.HashPassword(user, model.Password);
            if (hash != user.PasswordHash)
                return new() { IsSuccess = false };

            return await _tokenService.CreateAuthenticationResponseAsync(user, cancellationToken);
        }

        public async Task<User> GetMeAsync(ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken = default)
        {
            var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userId, out var guid))
                throw new InvalidOperationException("Invalid user id");
            return await _repository.GetUserByIdAsync(guid, cancellationToken);
        }
    }
}