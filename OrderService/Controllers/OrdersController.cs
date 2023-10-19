using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.Commands.Request;

namespace OrderService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("orders")]
        public async Task<IActionResult> CreateAsync(CreateOrderCommandRequest createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);
            return Ok(response);
        }
    }
}
