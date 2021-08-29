using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Products.Interfaces;
using AwesomeShop.BusinessLogic.Products.Requests;
using AwesomeShop.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AwesomeShop.BusinessLogic.Products.Responses;
using AwesomeShop.BusinessLogic.Shared;
using AwesomeShop.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace AwesomeShop.BusinessLogic.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly ISieveProcessor _processor;

        public ProductService(IMapper mapper, ApplicationDbContext context, ISieveProcessor processor)
        {
            _mapper = mapper;
            _context = context;
            _processor = processor;
        }


        public async Task<ProductListViewModel> GetAllProductsAsync(GetAllProductsRequest request,
            CancellationToken cancellationToken = default)
        {
            var model = new SieveModel
            {
                Filters = request.Filters, Sorts = request.Sorts, Page = request.Page, PageSize = request.PageSize
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

        public Task<ProductViewModel> FindByIdProductAsync(Guid id, CancellationToken cancellationToken = default) =>
            GetQueryable()
                .FirstOrDefaultAsync(model => model.Id == id, cancellationToken);


        public async Task CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var product = _mapper.Map<CreateProductRequest, Product>(request);
            await UpdateDeliveryCountries(request, product, cancellationToken);
            await UpdateCategories(request, product, cancellationToken);
            _context.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateProductAsync(Guid productId, UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _context
                .Products
                .Include(product => product.Categories)
                .Include(product => product.DeliveryCountries)
                .FirstOrDefaultAsync(product => product.Id == productId, cancellationToken);
            if (productToUpdate is null)
                throw new ResourceNotFoundException();

            _mapper.Map(request, productToUpdate);
            await UpdateDeliveryCountries(request, productToUpdate, cancellationToken);
            await UpdateCategories(request, productToUpdate, cancellationToken);
            _context.Update(productToUpdate);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProductAsync(Guid productId, CancellationToken cancellationToken)
        {
            var productToDelete = await _context.Products
                .FirstOrDefaultAsync(product => product.Id == productId, cancellationToken);
            if (productToDelete is null)
                throw new ResourceNotFoundException();
            _context.Remove(productToDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }


        // TODO: Refactor because im dont know how to use many-to-many
        private async Task UpdateDeliveryCountries(ProductRequestBase request, Product newProduct,
            CancellationToken cancellationToken, bool validate = true)
        {
            var manufacturers = await _context
                .Manufacturers
                .Where(manufacturer =>
                    request.DeliveryCountriesDtos
                        .Select(dto => dto.ManufacturerId)
                        .Contains(manufacturer.Id)
                )
                .ToDictionaryAsync(manufacturer => manufacturer.Id, cancellationToken);

            var delivery = request
                .DeliveryCountriesDtos
                .Where(dto => manufacturers.ContainsKey(dto.ManufacturerId))
                .Select(_mapper.Map<DeliveryCountry>)
                .Select(country =>
                {
                    country.ProductId = newProduct.Id;
                    return country;
                })
                .ToList();

            if (validate && delivery.Count != request.DeliveryCountriesDtos.Count)
                throw new ValidationException("Invalid manufacturers");

            _context.RemoveRange(newProduct.DeliveryCountries);
            _context.AddRange(delivery);
        }

        // TODO: Refactor because im dont know how to use many-to-many
        private async Task UpdateCategories(ProductRequestBase request, Product newProduct, CancellationToken cancellationToken,
            bool validate = true)
        {
            var categoryIds = request.CategoryIds.ToHashSet();

            var categories = await _context
                .Categories
                .Where(category => categoryIds.Contains(category.Id))
                .ToListAsync(cancellationToken);

            if (validate && categoryIds.Count != categories.Count)
                throw new ValidationException("Invalid categories");

            newProduct.Categories.Clear();
            newProduct.Categories.AddRange(categories);
        }

        private IQueryable<ProductViewModel> GetQueryable() =>
            _context
                .Products
                .AsNoTracking()
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
    }
}