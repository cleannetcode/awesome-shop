using System;
using System.Security.Cryptography;
using System.Text;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Accounts.Requests;

namespace AwesomeShop.BusinessLogic.Accounts.Services
{
    public class Hasher : IHasher
    {
        public string HashPassword(User user, string password)
        {
            using var hmacsha256 = new HMACSHA256();
            var hashBytes = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(password + user.Username));
            
            for (var i = 0; i < 1_000; i++)
            {
                hashBytes = hmacsha256.ComputeHash(hashBytes);
            }

            return Convert.ToHexString(hashBytes);
        }
    }
}