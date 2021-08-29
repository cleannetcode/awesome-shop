using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Shared;
using AwesomeShop.Data;
using Microsoft.EntityFrameworkCore;

namespace AwesomeShop.BusinessLogic.Accounts.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LockoutUserAsync(Guid userId, TimeSpan lockoutTime, CancellationToken cancellationToken = default)
        {
            var userToLockout = await _context.Members.FirstOrDefaultAsync(
                user => user.Id == userId, cancellationToken);
            if (userToLockout is null)
                throw new ResourceNotFoundException();
            
            userToLockout.LockoutDate = DateTime.UtcNow.Add(lockoutTime);
            _context.Update(userToLockout);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RevokeLockoutUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var userToLockout = await _context.Members.FirstOrDefaultAsync(
                user => user.Id == userId, cancellationToken);
            if (userToLockout is null)
                throw new ResourceNotFoundException();

            userToLockout.LockoutDate = null;
            _context.Update(userToLockout);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}