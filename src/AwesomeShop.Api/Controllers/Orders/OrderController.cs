using AwesomeShop.Api.Contracts;
using AwesomeShop.BusinessLogic.Orders.Interfaces;
using AwesomeShop.BusinessLogic.Orders.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.Api.Controllers.Orders
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController: ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [Authorize]
        [HttpPost("create")]
        [ProducesResponseType(typeof(OrderViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(NewOrderRequest newOrderRequest, CancellationToken cancellationToken = default)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var createdOrder = await _orderService.CreateAsync(userId, newOrderRequest);

            return Ok(createdOrder);
        }
    }
}
