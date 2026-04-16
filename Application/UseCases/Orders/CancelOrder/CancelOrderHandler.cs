using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Orders.CancelOrder
{
    public class CancelOrderHandler(IOrderRepository orderRepository) : IRequestHandler<CancelOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            if (order is null)
                return false;

            var result = order.Cancel();

            if (!result.IsSuccess)
                return false;

            await _orderRepository.UpdateAsync(order);

            return true;
        }
    }
}
