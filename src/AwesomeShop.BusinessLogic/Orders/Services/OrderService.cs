using AutoMapper;
using AwesomeShop.Api.Contracts;
using AwesomeShop.BusinessLogic.Orders.Interfaces;
using AwesomeShop.BusinessLogic.Orders.Responses;
using AwesomeShop.Data;
using AwesomeShop.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Orders.Services
{
    public class OrderService: IOrderService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Guid> CreateAsync(Guid userId, NewOrderRequest newOrderRequest)
        {
            if (newOrderRequest == null)
                throw new ArgumentNullException(nameof(newOrderRequest), "Can't create empty order");

            if (newOrderRequest.DeliveryCountries?.Count == 0)
                throw new ArgumentException("Can't create order without products");

            var productOrders = newOrderRequest.DeliveryCountries.Select(x => new ProductOrder
            {
                DeliveryCountryId = x.DeliveryCountryId,
                Amount = x.Amount
            }).ToList();

            var order = await _dbContext.Orders.AddAsync(new Order()
            {
                UserId = userId,
                CreationDate = DateTime.Now,
                ProductOrders = productOrders
            });

            return order.Entity.Id;
        }
    }
}
