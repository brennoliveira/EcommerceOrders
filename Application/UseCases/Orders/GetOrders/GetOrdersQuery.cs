using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Orders.GetOrders
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {
        public OrderStatus? Status { get; set; }
        public Guid? UserId { get; set; }
    }

    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
