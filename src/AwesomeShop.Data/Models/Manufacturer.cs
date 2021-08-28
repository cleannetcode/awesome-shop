using System;
using System.Collections.Generic;

#nullable disable

namespace AwesomeShop.Data.Models
{
    public class Manufacturer
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Name { get; set; }
        
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string Description { get; set; }

        public List<DeliveryCountry> DeliveryCountries { get; set; } = new();

        public List<Order> Orders { get; set; } = new();
    }
}
