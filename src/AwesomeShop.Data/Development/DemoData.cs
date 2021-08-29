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
            var image =
                "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";
            
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
                ImageBase64 = image,
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
                ImageBase64 = image,
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
                ImageBase64 = image,
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
                ImageBase64 = image,
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