using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Accounts.Requests;
using AwesomeShop.Data;
using AwesomeShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeShop.BusinessLogic.Accounts.Services
{
    public class UserService : IUserService
    {
        private readonly IUserCommonRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IHasher _hasher;
        private readonly ApplicationDbContext _context;

        public UserService(IUserCommonRepository repository, ITokenService tokenService, IHasher hasher, ApplicationDbContext context)
        {
            _repository = repository;
            _tokenService = tokenService;
            _hasher = hasher;
            _context = context;
        }

        public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest request, Guid roleId,
            CancellationToken cancellationToken = default)
        {
            var duplicate = await _repository.GetUserByNameAsync(request.Username, cancellationToken);
            if (duplicate is not null)
                return new() { IsSuccess = false };
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId, cancellationToken);
            if (role is null)
                return new() { IsSuccess = false };
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                RoleId = roleId
            };
            user.PasswordHash = _hasher.HashPassword(user, request.Password);
            await _repository.CreateUserAsync(user, cancellationToken);
            user = await _repository.GetUserByIdAsync(user.Id, cancellationToken);
            return await _tokenService.CreateAuthenticationResponseAsync(user, cancellationToken);
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginRequest model, CancellationToken cancellationToken = default)
        {
            var user = await _repository.GetUserByNameAsync(model.Username, cancellationToken);
            if (user is null)
                return new() { IsSuccess = false };
            if (user.LockoutDate > DateTime.UtcNow)
                return new()
                {
                    IsSuccess = false
                };
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