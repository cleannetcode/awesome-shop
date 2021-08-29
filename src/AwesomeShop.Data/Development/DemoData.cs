using System.Collections.Generic;
using AwesomeShop.Data.Models;

namespace AwesomeShop.Data.Development
{
    public class DemoData
    {
        public List<Product> Products { get; }

        public DemoData()
        {
            var firstManufacturer = new Manufacturer
            {
                Id = new("3fa85f64-5717-4577-b3fc-2c963f66afa6"),
                City = "Moscow",
                Country = "Russia", 
                Description = "The best of manufacturers",
                Name = "First Manufacturer"
            };

            var secondManufacturer = new Manufacturer
            {
                Id = new("3fa85f64-5755-4577-b3fc-2c963f66afa6"),
                City = "Saint Petersburg",
                Country = "Russia",
                Description = "The second of manufacturers",
                Name = "Second Manufacturer"
            };

            var phoneCategory = new Category
            {
                Id = new("3fa85f64-5755-4577-b88c-2c963f66afa6"),
                Name = "Phone"
            };

            var deviceCategory = new Category
            {
                Id = new("3fa85f64-5755-4577-ccfc-2c963f66afa6"),
                Name = "Device"
            };

            var ecoCategory = new Category
            {
                Name = "Eco"
            };

            Products = new()
            {
                new()
                {
                    Id = new("3fa85f64-5755-4577-b3fc-2c963f66afa7"),
                    Name = "PhoneRRU850",
                    Description = "Smart phone",
                    Categories =
                    {
                        ecoCategory, deviceCategory, phoneCategory
                    },
                    Cost = 450M,
                    DeliveryCountries =
                    {
                        new()
                        {
                            CountryName = "Russia", Manufacturer = firstManufacturer
                        },
                        new()
                        {
                            CountryName = "Russia", Manufacturer = secondManufacturer
                        },
                    }
                },
                new()
                {
                    Id = new("3fa85f64-5755-4577-b3fc-2c963f66afa8"),
                    Name = "PhoneZRRU400",
                    Description = "Home phone",
                    Categories =
                    {
                        phoneCategory
                    },
                    Cost = 100M,
                    DeliveryCountries =
                    {
                        new()
                        {
                            CountryName = "Russia", Manufacturer = firstManufacturer
                        },
                        new()
                        {
                            CountryName = "Russia", Manufacturer = secondManufacturer
                        },
                    }
                },
                new()
                {
                    Id = new("3fa85f64-5755-4577-b3fc-2c963f66afa9"),
                    Name = "PhoneRRU810",
                    Description = "Smart phone",
                    Categories =
                    {
                        deviceCategory, phoneCategory
                    },
                    Cost = 450M,
                    DeliveryCountries =
                    {
                        new()
                        {
                            CountryName = "Russia", Manufacturer = firstManufacturer
                        }
                    }
                },
                new()
                {
                    Id = new("3fa85f64-5755-4577-b3fc-2c963f66afb1"),
                    Name = "EcoBootsZU777",
                    Description = "Boots",
                    Categories =
                    {
                        ecoCategory
                    },
                    Cost = 300M,
                    DeliveryCountries =
                    {
                        new()
                        {
                            CountryName = "Russia", Manufacturer = secondManufacturer
                        },
                    }
                }
            };
        }
    }
}