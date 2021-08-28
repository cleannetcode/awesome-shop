using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Accounts.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AwesomeShop.BusinessLogic.Accounts.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<TokenIssuerOptions> _optionsHandler;
        private readonly IUserClaimsFactory _factory;

        public TokenService(IOptions<TokenIssuerOptions> optionsHandler, IUserClaimsFactory factory)
        {
            _optionsHandler = optionsHandler;
            _factory = factory;
        }

        public async Task<AuthenticationResponse> CreateAuthenticationResponseAsync(User user, CancellationToken cancellationToken = default)
        {
            var options = _optionsHandler.Value;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(options.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new(await _factory.GetClaimsAsync(user), JwtBearerDefaults.AuthenticationScheme),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return new() { AccessToken = accessToken, UserId = user.Id };
        }
    }
}