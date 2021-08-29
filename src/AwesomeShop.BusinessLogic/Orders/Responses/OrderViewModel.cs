using System;
using System.Collections.Generic;

namespace AwesomeShop.BusinessLogic.Orders.Responses
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public List<ProductDto> Products { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public string Address { get; set; }

        public UserDto User { get; set; }

        public decimal TotalPrice { get; set; }
        
        public class UserDto
        {
            public Guid Id { get; set; }
        
            public string Username { get; set; }
        
            public DateTime BirthDate { get; set; }
        
            public Guid RoleId { get; set; }
        
            public string Role { get; set; }

            public DateTime? LockoutDate { get; set; }
        }
        
        public class ManufacturerDto
        {
            public Guid Id { get; set; }
            
            public string Name { get; set; }
        
            public string Country { get; set; }
        
            public string City { get; set; }
        
            public string Description { get; set; }
        }
        
        public class ProductDto
        {
            public Guid Id { get; set; }
        
            public string Name { get; set; }
        
            public decimal Cost { get; set; }
            
            public DateTime CreationDate { get; set; }
        
            public string Description { get; set; }

            public string Country { get; set; }

            public ManufacturerDto Manufacturer { get; set; }
        }
    }
}