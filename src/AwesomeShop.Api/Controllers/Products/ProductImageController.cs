using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Products.Interfaces;
using AwesomeShop.BusinessLogic.Products.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Api.Controllers.Products
{
    [ApiController]
    [Route("api/v1/products/{productId:guid}/image")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductImageController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostImage(Guid productId, ProductImage image, CancellationToken cancellationToken)
        {
            await _service.AddImageByIdAsync(productId, image, cancellationToken);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetImage(Guid productId, CancellationToken cancellationToken)
        {
            var image = await _service.FindImageByIdAsync(productId, cancellationToken);
            if (image is null || string.IsNullOrWhiteSpace(image.ImageBase64))
                return NotFound();
            var bytes = Convert.FromBase64String(image.ImageBase64);
            return new FileContentResult(bytes, image.ImageBase64Mime);
        }
    }
}