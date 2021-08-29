using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Products.Interfaces;
using AwesomeShop.BusinessLogic.Products.Requests;
using AwesomeShop.BusinessLogic.Products.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Api.Controllers.Products
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateProductAsync(request, cancellationToken);
            return NoContent();
        }

        [HttpPut("{productId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid productId, [FromBody] UpdateProductRequest request,
            CancellationToken cancellationToken)
        {
            await _service.UpdateProductAsync(productId, request, cancellationToken);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductListViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsRequest request,
            CancellationToken cancellationToken) =>
            Ok(await _service.GetAllProductsAsync(request, cancellationToken));

        [HttpGet("{productId:guid}")]
        [ProducesResponseType(typeof(ProductListViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindProduct(Guid productId,
            CancellationToken cancellationToken)
        {
            var result = (await _service.FindByIdProductAsync(productId, cancellationToken));
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{productId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid productId, CancellationToken cancellationToken)
        {
            await _service.DeleteProductAsync(productId, cancellationToken);
            return NoContent();
        }
    }
}