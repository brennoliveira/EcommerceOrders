using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public Order(Guid userId, List<OrderItem> items)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("Order must contain at least one item.");

            Id = Guid.NewGuid();
            UserId = userId;
            Items = items;
            Status = OrderStatus.Iniciado;
        }

        public bool CanBeUpdated()
        {
            return Status == OrderStatus.Iniciado;
        }

        public bool CanBeCanceled()
        {
            return Status == OrderStatus.Iniciado || Status == OrderStatus.Processado;
        }

        public bool CanBeShipped()
        {
            return Status == OrderStatus.Processado;
        }

        public Result Update(List<OrderItem> newItems)
        {
            if (!CanBeUpdated())
                return Result.Failure("Order cannot be updated in its current status.");

            if (newItems == null || !newItems.Any())
                return Result.Failure("Order must contain at least one item.")
                    ;
            Items = newItems;
            return Result.Success();
        }

        public Result Cancel()
        {
            if (!CanBeCanceled())
                return Result.Failure("Order cannot be canceled in its current status.");

            Status = OrderStatus.Cancelado;
            return Result.Success();
        }

        public Result Ship()
        {
            if (!CanBeShipped())
                return Result.Failure("Order cannot be shipped in its current status.");
         
            Status = OrderStatus.Enviado;
            return Result.Success();
        }
    }
}