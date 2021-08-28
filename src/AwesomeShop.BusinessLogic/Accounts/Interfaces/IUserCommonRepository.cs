using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.Data.Models;

namespace AwesomeShop.BusinessLogic.Accounts.Interfaces
{
    public interface IUserCommonRepository
    {
        Task CreateUserAsync(User user, CancellationToken cancellationToken = default);

        Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<User> GetUserByNameAsync(string username, CancellationToken cancellationToken = default);
    }
}