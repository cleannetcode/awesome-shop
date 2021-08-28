using System;
using System.Security.Cryptography;
using System.Text;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.Data.Models;

namespace AwesomeShop.BusinessLogic.Accounts.Services
{
    public class Hasher : IHasher
    {
        public string HashPassword(User user, string password)
        {
            using var alg = SHA256.Create();
            var hashBytes = alg.ComputeHash(Encoding.UTF8.GetBytes(password + user.Username));

            return Convert.ToHexString(hashBytes);
        }
    }
}