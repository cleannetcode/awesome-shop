using System;

namespace AwesomeShop.BusinessLogic.Accounts.Requests
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public Role Role { get; set; }
    }

    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}