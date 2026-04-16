using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Orders.GetOrders
{
    public class GetOrdersHandler(IOrderRepository repository) : IRequestHandler<GetOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _repository = repository; 

        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellation)
        {
            var orders = await _repository.GetAllAsync();

            if (request.Status.HasValue)
                orders = orders.Where(o => o.Status == request.Status).ToList();

            if (request.UserId.HasValue)
                orders = orders.Where(o => o.UserId == request.UserId).ToList();

            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                UserId = o.UserId,
                Status = o.Status.ToString()
            }).ToList();
        }
    }
}
