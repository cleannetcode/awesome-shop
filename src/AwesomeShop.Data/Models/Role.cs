using System;
using System.Collections.Generic;

#nullable disable

namespace AwesomeShop.Data.Models
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Name { get; set; }

        public List<User> Users { get; set; } = new();
    }
}
