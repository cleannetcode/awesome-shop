using System;
using System.Collections.Generic;

#nullable disable

namespace AwesomeShop.Data.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
