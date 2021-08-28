using System.Collections.Generic;

#nullable disable

namespace AwesomeShop.Data.Models
{
    public class Manufacturer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }

        public List<DeliveryCountry> DeliveryCountries { get; set; }
        public List<Order> Orders { get; set; }
    }
}
