#nullable disable

using System;
using System.Collections.Generic;

namespace AwesomeShop.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public DateTime CreationDate { get; set; }
        
        public string Address { get; set; }
        
        public Guid UserId { get; set; }
        
        public User User { get; set; }
        
        public List<ProductOrder> ProductOrders { get; set; } = new();
    }
}
