using AwesomeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Manufacturer.Requests
{
    public class ManufacturerRequestBase
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Description { get; set; }

        public List<DeliveryCountryDto> DeliveryCountries { get; set; } = new();
        
        public class DeliveryCountryDto
        {
            public Guid ManufacturerId { get; set; }

            [Required]
            public string CountryName { get; set; }
        }

    }
}
