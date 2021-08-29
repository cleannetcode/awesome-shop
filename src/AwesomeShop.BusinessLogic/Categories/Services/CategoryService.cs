using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AwesomeShop.BusinessLogic.Categories.Interfaces;
using AwesomeShop.BusinessLogic.Categories.Requests;
using AwesomeShop.BusinessLogic.Categories.Responses;
using AwesomeShop.BusinessLogic.Shared;
using AwesomeShop.Data;
using AwesomeShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeShop.BusinessLogic.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync(
            CancellationToken cancellationToken = default) =>
            await GetQueryable().ToListAsync(cancellationToken);

        public async Task<CategoryViewModel> FindByIdCategoryAsync(Guid id, CancellationToken cancellationToken = default) =>
            await GetQueryable().FirstOrDefaultAsync(category => category.Id == id, cancellationToken);

        public async Task CreateCategoryAsync(CreateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var category = _mapper.Map<CreateCategoryRequest, Category>(request);
            _context.Add(category);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCategoryAsync(Guid categoryId, UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await _context
                .Categories
                .FirstOrDefaultAsync(
                    c => c.Id == categoryId,
                    cancellationToken);
            if (categoryToUpdate is null)
                throw new ResourceNotFoundException();
            _mapper.Map(request, categoryToUpdate);
            _context.Update(categoryToUpdate);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _context
                .Categories
                .FirstOrDefaultAsync(
                    c => c.Id == categoryId,
                    cancellationToken);
            if (categoryToDelete is null)
                throw new ResourceNotFoundException();
            _context.Remove(categoryToDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<CategoryViewModel> GetQueryable() =>
            _context
                .Categories
                .AsNoTracking()
                .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);
    }
}