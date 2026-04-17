using Application.UseCases.Orders.CreateOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public List<CreateOrderItemDto> Items { get; set; } = [];
    }
}
