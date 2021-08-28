using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Requests;

namespace AwesomeShop.BusinessLogic.Accounts.Interfaces
{
    public interface ITokenService
    {
        Task<AuthenticationResponse> CreateAuthenticationResponseAsync(User user, CancellationToken cancellationToken = default);
    }
}