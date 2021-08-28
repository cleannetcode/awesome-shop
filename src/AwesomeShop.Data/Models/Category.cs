using System;
using System.Collections.Generic;

#nullable disable

namespace AwesomeShop.Data.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
