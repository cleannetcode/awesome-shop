using System.ComponentModel.DataAnnotations;

namespace AwesomeShop.BusinessLogic.Accounts.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}