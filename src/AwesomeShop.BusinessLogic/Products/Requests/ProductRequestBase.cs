using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AwesomeShop.BusinessLogic.Products.Requests
{
    public class ProductRequestBase
    {
        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Cost { get; set; }

        public string Description { get; set; }

        [MinLength(1)]
        public List<DeliveryCountryDto> DeliveryCountriesDtos { get; set; } = new();

        [MinLength(1)]
        public List<Guid> CategoryIds { get; set; } = new();

        public class DeliveryCountryDto
        {
            public Guid ManufacturerId { get; set; }

            [Required]
            public string CountryName { get; set; }
        }
    }
}