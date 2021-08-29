﻿using AwesomeShop.Api.Contracts;
using AwesomeShop.BusinessLogic.Orders.Responses;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Orders.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderResponse> CreateAsync(Guid userId, NewOrderRequest newOrderRequest);
    }
}
