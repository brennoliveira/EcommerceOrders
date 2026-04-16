using Application.UseCases.Orders.GetOrders;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Orders.GetOrderById
{
    public class GetOrderByIdHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderByIdQuery, OrderDto?>
    {
        public readonly IOrderRepository _orderRepository = orderRepository;

        public async Task<OrderDto?> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(query.Id);
            if (order == null)
                return null;

            return new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                Status = order.Status.ToString(),
            };
        }
    }
}
