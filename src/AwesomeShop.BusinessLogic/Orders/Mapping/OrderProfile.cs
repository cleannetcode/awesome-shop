using System.Linq;
using AutoMapper;
using AwesomeShop.BusinessLogic.Orders.Responses;
using AwesomeShop.Data.Models;

namespace AwesomeShop.BusinessLogic.Orders.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(d => d.TotalPrice,
                    o => o.MapFrom(order =>
                        order.ProductOrders.Select(productOrder => productOrder.DeliveryCountry.Product.Cost).Sum()))
                .ForMember(d => d.Products,
                    o => o.MapFrom(
                        order => order.ProductOrders.Select(productOrder => new OrderViewModel.ProductDto
                        {
                            Id = productOrder.DeliveryCountry.ProductId,
                            Cost = productOrder.DeliveryCountry.Product.Cost,
                            Country = productOrder.DeliveryCountry.CountryName,
                            CreationDate = productOrder.DeliveryCountry.Product.CreationDate,
                            Description = productOrder.DeliveryCountry.Product.Description,
                            Manufacturer = new()
                            {
                                City = productOrder.DeliveryCountry.Manufacturer.City,
                                Country = productOrder.DeliveryCountry.Manufacturer.Country,
                                Description = productOrder.DeliveryCountry.Manufacturer.Description,
                                Id = productOrder.DeliveryCountry.ManufacturerId,
                                Name = productOrder.DeliveryCountry.Manufacturer.Name
                            }
                        })))
                .ForMember(d => d.User, o => o.MapFrom(order => order.User));
            CreateMap<User, OrderViewModel.UserDto>();
        }
    }
}