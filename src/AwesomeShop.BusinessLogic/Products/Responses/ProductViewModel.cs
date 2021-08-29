using System;
using System.Collections.Generic;
using Sieve.Attributes;

namespace AwesomeShop.BusinessLogic.Products.Responses
{
    public class ProductViewModel
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid Id { get; set; }
        
        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }
        
        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Cost { get; set; }
        
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime CreationDate { get; set; }
        
        [Sieve(CanFilter = true, CanSort = true)]
        public string Description { get; set; }
        
        [Sieve(CanFilter = true)]
        public List<DeliveryCountryDto> DeliveryCountries { get; set; } = new();
        
        [Sieve(CanFilter = true)]
        public List<CategoryDto> Categories { get; set; } = new();
        
        public class DeliveryCountryDto
        {
            public Guid Id { get; set; }
        
            public Guid ProductId { get; set; }
        
            public Guid ManufacturerId { get; set; }
        
            public string CountryName { get; set; }
        }
        
        public class CategoryDto
        {
            public Guid Id { get; set; }
        
            public string Name { get; set; }
        }
    }
}