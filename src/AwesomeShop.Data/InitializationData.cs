using System;
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
                Id = new Guid("146c287c-7695-4e5f-873d-7a929e60e085"),
                BirthDate = new(2000, 1, 1),
                Username = "admin",
                RoleId = AdminRole.Id
            };
            Admin.PasswordHash = hasher.HashPassword(Admin, "password");
        }
    }
}