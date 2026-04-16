using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Orders.CreateOrder
{
    public class CreateOrderHandler(IOrderRepository repository) : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _repository = repository;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var items = request.Items.Select(i =>
            new OrderItem(i.ProductId, i.Quantity, i.UnitPrice)).ToList();

            var order = new Order(request.UserId, items);

            await _repository.AddAsync(order);

            return order.Id;    
        }
    }
}
