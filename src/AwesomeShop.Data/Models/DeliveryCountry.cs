#nullable disable

using System;

namespace AwesomeShop.Data.Models
{
    public class DeliveryCountry
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public Guid? ProductId { get; set; }
        
        public Guid ManufacturerId { get; set; }
        
        public string CountryName { get; set; }

        public Manufacturer Manufacturer { get; set; }
        
        public Product Product { get; set; }
    }
}
