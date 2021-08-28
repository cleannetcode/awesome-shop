#nullable disable

using System;

namespace AwesomeShop.Data.Models
{
    public class ProductOrder
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Guid DeliveryCountryId { get; set; }
        public Guid OrderId { get; set; }
        public DeliveryCountry DeliveryCountry { get; set; }
        public Order Order { get; set; }
    }
}
