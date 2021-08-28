using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.Data;
using AwesomeShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeShop.BusinessLogic.Accounts.Services
{
    public class UserCommonRepository : IUserCommonRepository
    {
        private readonly ApplicationDbContext _context;

        public UserCommonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
        
        public Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            _context.Members.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        public Task<User> GetUserByNameAsync(string username, CancellationToken cancellationToken = default) =>
            _context.Members.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }
}