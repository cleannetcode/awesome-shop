using System;
using System.Collections.Generic;

#nullable disable

namespace AwesomeShop.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Name { get; set; }
        
        public decimal Cost { get; set; }
        
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        
        public string Description { get; set; }

        public List<DeliveryCountry> DeliveryCountries { get; set; } = new();
        
        public List<Category> Categories { get; set; } = new();
    }
}
