using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Accounts.Requests;
using AwesomeShop.Data.Models;

namespace AwesomeShop.BusinessLogic.Accounts.Services
{
    public class UserClaimsFactory : IUserClaimsFactory
    {
        public Task<List<Claim>> GetClaimsAsync(User user)
        {
            var role = user.Role.Name;
            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Username),
            };
            return Task.FromResult(claims);
        }
    }
}