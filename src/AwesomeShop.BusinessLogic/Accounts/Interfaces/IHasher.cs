using AwesomeShop.BusinessLogic.Accounts.Requests;

namespace AwesomeShop.BusinessLogic.Accounts.Interfaces
{
    public interface IHasher
    {
        string HashPassword(AwesomeShop.Data.Models.User user, string password);
    }
}