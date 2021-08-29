using AwesomeShop.BusinessLogic.Manufacturer.Interfaces;
using AwesomeShop.BusinessLogic.Manufacturer.Requests;
using AwesomeShop.BusinessLogic.Manufacturer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.Api.Controllers.Manufacturers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _service;

        public ManufacturerController(IManufacturerService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateManufacturer(CreateManufacturerRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateManufacturerAsync(request, cancellationToken);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{manufacturerId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateManufacturer([FromRoute] Guid manufacturerId, [FromBody] UpdateManufacturerRequest request,
            CancellationToken cancellationToken)
        {
            await _service.UpdateManufacturerAsync(manufacturerId, request, cancellationToken);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ManufacturerListViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllManufacturersRequest request,
            CancellationToken cancellationToken) =>
            Ok(await _service.GetAllManufacturersAsync(request, cancellationToken));

        [HttpGet("{manufacturerId:guid}")]
        [ProducesResponseType(typeof(ManufacturerListViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindManufacturer(Guid productId,
            CancellationToken cancellationToken)
        {
            var result = (await _service.FindByIdManufacturerAsync(productId, cancellationToken));
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{manufacturerId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid productId, CancellationToken cancellationToken)
        {
            await _service.DeleteManufacturerAsync(productId, cancellationToken);
            return NoContent();
        }
    }
}
