using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Categories.Interfaces;
using AwesomeShop.BusinessLogic.Categories.Requests;
using AwesomeShop.BusinessLogic.Categories.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Api.Controllers.Categories
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateCategoryAsync(request, cancellationToken);
            return NoContent();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPut("{categoryId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid categoryId, [FromBody] UpdateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            await _service.UpdateCategoryAsync(categoryId, request, cancellationToken);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken) =>
            Ok(await _service.GetAllCategoriesAsync(cancellationToken));

        [HttpGet("{categoryId:guid}")]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindCategory(Guid categoryId,
            CancellationToken cancellationToken)
        {
            var result = (await _service.FindByIdCategoryAsync(categoryId, cancellationToken));
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{categoryId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid categoryId, CancellationToken cancellationToken)
        {
            await _service.DeleteCategoryAsync(categoryId, cancellationToken);
            return NoContent();
        }
    }
}