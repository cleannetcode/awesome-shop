using System.ComponentModel.DataAnnotations;

namespace AwesomeShop.BusinessLogic.Accounts.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}