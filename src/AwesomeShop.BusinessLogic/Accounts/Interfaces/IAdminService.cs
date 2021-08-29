using System;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Accounts.Interfaces
{
    public interface IAdminService
    {
        Task LockoutUserAsync(Guid userId, TimeSpan lockoutTime, CancellationToken cancellationToken = default);

        Task RevokeLockoutUserAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}