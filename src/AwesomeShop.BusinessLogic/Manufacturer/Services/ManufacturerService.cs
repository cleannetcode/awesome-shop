using AutoMapper;
using AutoMapper.QueryableExtensions;
using AwesomeShop.BusinessLogic.Manufacturer.Interfaces;
using AwesomeShop.BusinessLogic.Manufacturer.Requests;
using AwesomeShop.BusinessLogic.Manufacturer.Responses;
using AwesomeShop.BusinessLogic.Shared;
using AwesomeShop.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Manufacturer.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly ISieveProcessor _processor;

        public ManufacturerService(IMapper mapper, ApplicationDbContext context, ISieveProcessor processor)
        {
            _mapper = mapper;
            _context = context;
            _processor = processor;
        }

        public async Task CreateManufacturerAsync(CreateManufacturerRequest request, CancellationToken cancellationToken = default)
        {
            var manufacturer = _mapper.Map<CreateManufacturerRequest, Data.Models.Manufacturer>(request);
            _context.Add(manufacturer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteManufacturerAsync(Guid manufacturerId, CancellationToken cancellationToken)
        {
            var manufacturerToDelete = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == manufacturerId, cancellationToken);
            if (manufacturerToDelete is null)
                throw new ResourceNotFoundException();
            _context.Remove(manufacturerToDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<ManufacturerViewModel> FindByIdManufacturerAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return GetQueryable()
                    .FirstOrDefaultAsync(model => model.Id == id, cancellationToken);
        }

        public async Task<ManufacturerListViewModel> GetAllManufacturersAsync(GetAllManufacturersRequest request, CancellationToken cancellationToken = default)
        {
            var model = new SieveModel
            {
                Filters = request.Filters,
                Sorts = request.Sorts,
                Page = request.Page,
                PageSize = request.PageSize
            };
            int? totalCount = null;
            
            if (request.IsNeedTotalCount)
            {
                var countQuery = _processor.Apply(model, GetQueryable(), applyPagination: false, applySorting: false);
                totalCount = await countQuery.CountAsync(cancellationToken);
            }

            var mainQuery = _processor.Apply(model, GetQueryable());
            var items = await mainQuery.ToListAsync(cancellationToken);

            return new()
            {
                Items = items,
                PageNumber = model.Page ?? 1,
                PageSize = items.Count,
                RequestedPageSize = model.PageSize ?? 10,
                TotalCount = totalCount
            };
        }

        public Task UpdateManufacturerAsync(Guid manufacturerId, UpdateManufacturerRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IQueryable<ManufacturerViewModel> GetQueryable() =>
            _context
            .Products
            .AsNoTracking()
            .ProjectTo<ManufacturerViewModel>(_mapper.ConfigurationProvider);
    }
}
