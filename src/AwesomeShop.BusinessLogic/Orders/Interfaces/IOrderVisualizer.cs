using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Orders.Requests;
using AwesomeShop.BusinessLogic.Orders.Responses;

namespace AwesomeShop.BusinessLogic.Orders.Interfaces
{
    public interface IOrderVisualizer
    {
        Task<OrderListViewModel> GetUserOrders(GetOrdersRequest request, Guid userId, CancellationToken cancellationToken);
        
        Task<OrderListViewModel> GetAllOrders(GetOrdersRequest request, CancellationToken cancellationToken);
    }
}