using System;
using System.Collections.Generic;

namespace AwesomeShop.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid CreatedUserId { get; set; }
        public ProductOrder Products { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
