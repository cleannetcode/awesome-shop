using AutoMapper;
using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Orders.Other;
using AwesomeShop.BusinessLogic.Orders.Responses;
using AwesomeShop.Data;
using AwesomeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Orders.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OrderViewModel> CreateAsync(Guid userId, List<DeliveryCountryAmount> deliveryCountries)
        {
            if (deliveryCountries?.Count == 0)
                throw new ArgumentException("Can't create order without products");

            var productOrders = deliveryCountries.Select(x => new ProductOrder
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

            return _mapper.Map<OrderViewModel>(order.Entity);
        }
    }
}
