using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.Data.Models;

namespace AwesomeShop.Data
{
    public class InitializationData
    {
        public User Admin { get; }
        
        public Role AdminRole { get; }
        
        public Role MemberRole { get; }

        public InitializationData(IHasher hasher)
        {
            AdminRole = new()
            {
                Name = "Admin",
                Id = IdManager.AdminRoleId
            };
            
            MemberRole = new()
            {
                Name = "Member",
                Id = IdManager.MemberRoleId
            };

            Admin = new()
            {
                Id = IdManager.Admin,
                BirthDate = new(2000, 1, 1),
                Username = "admin",
                RoleId = AdminRole.Id
            };
            Admin.PasswordHash = hasher.HashPassword(Admin, "password");
        }
    }
}