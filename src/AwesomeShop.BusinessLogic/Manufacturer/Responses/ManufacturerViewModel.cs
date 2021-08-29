using AwesomeShop.Data.Models;
using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Manufacturer.Responses
{
    public class ManufacturerViewModel
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Country { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string City { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Description { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public List<Data.Models.DeliveryCountry> DeliveryCountries { get; set; } = new();

        [Sieve(CanFilter = true, CanSort = true)]
        public List<Order> Orders { get; set; } = new();
    }
}
