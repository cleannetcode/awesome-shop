using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Categories.Requests;
using AwesomeShop.BusinessLogic.Categories.Responses;

namespace AwesomeShop.BusinessLogic.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
        
        Task<CategoryViewModel> FindByIdCategoryAsync(Guid id, CancellationToken cancellationToken = default);

        Task CreateCategoryAsync(CreateCategoryRequest request, CancellationToken cancellationToken = default);

        Task UpdateCategoryAsync(Guid productId, UpdateCategoryRequest request, CancellationToken cancellationToken);

        Task DeleteCategoryAsync(Guid productId, CancellationToken cancellationToken);
    }
}