using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Orders.UpdateOrder
{
    public class UpdateOrderHandler(IOrderRepository orderRepository) : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            if (order == null)
                return false;
            
            var items = request.Items.Select(i =>
                new OrderItem(i.ProductId, i.Quantity, i.UnitPrice)
                ).ToList();

            var result = order.Update(items);

            if (!result.IsSuccess)
                return false;

            return true;
        }
    }
}
