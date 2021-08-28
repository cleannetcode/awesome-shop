using System;

namespace AwesomeShop.BusinessLogic.Accounts.Requests
{
    public class UserResponse
    {
        public string Username { get; set; }

        public Guid Id { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }
    }
}