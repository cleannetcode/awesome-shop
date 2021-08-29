using AutoMapper;
using AwesomeShop.Api.Contracts;
using AwesomeShop.BusinessLogic.Orders.Responses;

namespace AwesomeShop.BusinessLogic.Orders.Mappings
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<NewOrderRequest, OrderViewModel>().ReverseMap();
        }
    }
}
