using System;

namespace AwesomeShop.BusinessLogic.Accounts.Requests
{
    public class CreateUserRequest: RegisterRequest
    {
        public Guid RoleId { get; set; }
    }
}