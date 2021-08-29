using AwesomeShop.BusinessLogic.Products.Responses;
using System;
using System.Collections.Generic;

namespace AwesomeShop.BusinessLogic.Orders.Responses
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public Guid CreatedUserId { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
