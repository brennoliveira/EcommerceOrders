using Application.UseCases.Orders.CancelOrder;
using Application.UseCases.Orders.CreateOrder;
using Application.UseCases.Orders.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetOrdersQuery query)
        {
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(); // TODO
        }

        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var command = new CancelOrderCommand { OrderId = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
