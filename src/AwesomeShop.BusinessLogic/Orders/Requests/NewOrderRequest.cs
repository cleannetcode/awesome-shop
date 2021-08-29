using AwesomeShop.BusinessLogic.Orders.Other;
using System;
using System.Collections.Generic;

namespace AwesomeShop.Api.Contracts
{
    public class NewOrderRequest
    {
        public List<DeliveryCountryAmount> DeliveryCountries { get; set; }
        public string Address { get; set; }
    }
}
