using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.BusinessLogic.Orders.Interfaces;
using AwesomeShop.BusinessLogic.Orders.Requests;
using AwesomeShop.BusinessLogic.Orders.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Api.Controllers.Orders
{ 
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderVisualizationController : ControllerBase
    {
        private readonly IOrderVisualizer _visualizer;

        public OrderVisualizationController(IOrderVisualizer visualizer)
        {
            _visualizer = visualizer;
        }

        [Authorize]
        [HttpGet("my")]
        [ProducesResponseType(typeof(OrderListViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMyOrders([FromQuery] GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdClaim, out var userId))
                return BadRequest();
            var result = await _visualizer.GetUserOrders(request, userId, cancellationToken);
            return Ok(result);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        [ProducesResponseType(typeof(OrderListViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var result = await _visualizer.GetAllOrders(request, cancellationToken);
            return Ok(result);
        }
    }
}