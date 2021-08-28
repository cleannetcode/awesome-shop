using AwesomeShop.BusinessLogic.Accounts.Requests;

namespace AwesomeShop.BusinessLogic.Accounts.Interfaces
{
    public interface IHasher
    {
        string HashPassword(User user, string password);
    }
}