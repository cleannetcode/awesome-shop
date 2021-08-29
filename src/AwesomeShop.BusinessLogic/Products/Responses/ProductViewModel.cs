using System;
using System.Collections.Generic;

namespace AwesomeShop.BusinessLogic.Products.Responses
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Cost { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public string Description { get; set; }
        
        public List<DeliveryCountryDto> DeliveryCountries { get; set; } = new();
        
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