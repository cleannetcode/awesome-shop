using System.Collections.Generic;
using AwesomeShop.Data.Models;

namespace AwesomeShop.Data.Development
{
    public class DemoData
    {
        public List<Product> Products { get; }

        public List<Order> Orders { get; }
        
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

            Product product1 = new()
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
            };
            Product product2 = new()
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
            };
            Product product3 = new()
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
            };
            Product product4 = new()
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
            };
            Products = new()
            {
                product1,
                product2,
                product3,
                product4
            };

            Order order1 = new()
            {
                Id = new("32285f64-5755-4577-b3fc-2c963f66afb1"),
                Address = "Moscorsdaw",
                UserId = IdManager.Admin,
                ProductOrders =
                {
                    new()
                    {
                        Amount = 1, 
                        DeliveryCountryId = product1.DeliveryCountries[0].Id,
                    },
                    new()
                    {
                        Amount = 1, 
                        DeliveryCountryId = product2.DeliveryCountries[0].Id,
                    },
                    new()
                    {
                        Amount = 1, 
                        DeliveryCountryId = product3.DeliveryCountries[0].Id,
                    },
                    new()
                    {
                        Amount = 1, 
                        DeliveryCountryId = product4.DeliveryCountries[0].Id,
                    }
                }
            };
            
            Order order2 = new()
            {
                Id = new("32285f77-5755-4577-b3fc-2c963f66afb1"),
                Address = "Awaewae",
                UserId = IdManager.Admin,
                ProductOrders =
                {
                    new()
                    {
                        Amount = 2, 
                        DeliveryCountryId = product1.DeliveryCountries[1].Id,
                    },
                    new()
                    {
                        Amount = 3, 
                        DeliveryCountryId = product2.DeliveryCountries[1].Id,
                    },
                    new()
                    {
                        Amount = 4, 
                        DeliveryCountryId = product3.DeliveryCountries[0].Id,
                    },
                    new()
                    {
                        Amount = 5, 
                        DeliveryCountryId = product4.DeliveryCountries[0].Id,
                    }
                }
            };

            Orders = new()
            {
                order1, order2
            };
        }
    }
}