using AwesomeShop.BusinessLogic.Orders.Other;
using AwesomeShop.BusinessLogic.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Orders.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderViewModel> CreateAsync(Guid userId, List<DeliveryCountryAmount> deliveryCountries);
    }
}
