using AwesomeShop.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Orders.Interfaces
{
    public interface IOrderService
    {
        public Task<Guid> CreateAsync(Guid userId, NewOrderRequest newOrderRequest);
    }
}
