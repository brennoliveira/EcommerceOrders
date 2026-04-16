using Application.UseCases.Orders.GetOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Orders.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto?>
    {
        public Guid Id { get; set; }
    }
}
