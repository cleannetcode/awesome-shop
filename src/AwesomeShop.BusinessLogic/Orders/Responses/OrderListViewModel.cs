using System.Collections.Generic;
using AwesomeShop.BusinessLogic.Shared.Responses;

namespace AwesomeShop.BusinessLogic.Orders.Responses
{
    public class OrderListViewModel : BaseListViewModel
    {
        public List<OrderViewModel> Items { get; set; }
    }
}