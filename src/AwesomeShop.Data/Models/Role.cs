using System;
using System.Collections.Generic;

#nullable disable

namespace AwesomeShop.Data.Models
{
    public class Role
    {

        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public List<User> Members { get; set; }
        public string Name { get; set; }
    }
}
