using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AwesomeShop.BusinessLogic.Orders.Interfaces;
using AwesomeShop.BusinessLogic.Orders.Requests;
using AwesomeShop.BusinessLogic.Orders.Responses;
using AwesomeShop.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace AwesomeShop.BusinessLogic.Orders.Services
{
    public class OrderVisualizer : IOrderVisualizer
    {
        private readonly ISieveProcessor _processor;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public OrderVisualizer(ISieveProcessor processor, ApplicationDbContext context, IMapper mapper)
        {
            _processor = processor;
            _mapper = mapper;
            _context = context;

        }

        public async Task<OrderListViewModel> GetUserOrders(GetOrdersRequest request, Guid userId,
            CancellationToken cancellationToken)
        {
            var model = MapModel(request);
            int? totalCount = null;

            if (request.IsNeedTotalCount)
            {
                var countQuery = _processor.Apply(
                    model,
                    GetQueryable(userId),
                    applyPagination: false,
                    applySorting: false);
                totalCount = await countQuery.CountAsync(cancellationToken);
            }

            var mainQuery = _processor.Apply(
                model, GetQueryable(userId));
            return await CreateModelAsync(mainQuery, model, totalCount, cancellationToken);
        }
        
        public async Task<OrderListViewModel> GetAllOrders(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var model = MapModel(request);
            int? totalCount = null;

            if (request.IsNeedTotalCount)
            {
                var countQuery = _processor.Apply(
                    model,
                    GetQueryable(),
                    applyPagination: false,
                    applySorting: false);
                totalCount = await countQuery.CountAsync(cancellationToken);
            }

            var mainQuery = _processor.Apply(
                model, GetQueryable());
            return await CreateModelAsync(mainQuery, model, totalCount, cancellationToken);
        }

        private static SieveModel MapModel(GetOrdersRequest request) =>
            new()
            {
                Filters = request.Filters, Sorts = request.Sorts, Page = request.Page, PageSize = request.PageSize
            };

        private static async Task<OrderListViewModel> CreateModelAsync(
            IQueryable<OrderViewModel> mainQuery, SieveModel model, int? totalCount, CancellationToken cancellationToken) =>
            new()
            {
                Items = await mainQuery.ToListAsync(cancellationToken),
                PageNumber = model.Page ?? 1,
                PageSize = (await mainQuery.ToListAsync(cancellationToken)).Count,
                RequestedPageSize = model.PageSize ?? 10,
                TotalCount = totalCount
            };
        
        

        private IQueryable<OrderViewModel> GetQueryable(Guid userId) =>
            _context
                .Orders
                .AsNoTracking()
                .Where(order => order.UserId == userId)
                .ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
        private IQueryable<OrderViewModel> GetQueryable() =>
            _context
                .Orders
                .AsNoTracking()
                .ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
    }
}