using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Products.Requests;
using AwesomeShop.BusinessLogic.Products.Responses;

namespace AwesomeShop.BusinessLogic.Products.Interfaces
{
    public interface IProductService
    {
        Task<ProductListViewModel> GetAllProductsAsync(GetAllProductsRequest request, CancellationToken cancellationToken = default);
        
        Task<ProductViewModel> FindByIdProductAsync(Guid id, CancellationToken cancellationToken = default);

        Task CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken = default);

        Task UpdateProductAsync(Guid productId, UpdateProductRequest request, CancellationToken cancellationToken);

        Task DeleteProductAsync(Guid productId, CancellationToken cancellationToken);
    }
}