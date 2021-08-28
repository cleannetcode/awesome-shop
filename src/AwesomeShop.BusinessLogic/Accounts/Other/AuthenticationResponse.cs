using System;

namespace AwesomeShop.BusinessLogic.Accounts.Requests
{
    public class AuthenticationResponse
    {
        public bool IsSuccess { get; set; } = true;

        public Guid UserId { get; set; }

        public string AccessToken { get; set; }
    }
}