using System;
using System.Collections.Generic;

#nullable disable

namespace AwesomeShop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }

        public List<DeliveryCountry> DeliveryCountries { get; set; }
        public List<User> Members { get; set; }
        public List<Order> Orders { get; set; }
        public List<Category> Categories { get; set; }
    }
}
