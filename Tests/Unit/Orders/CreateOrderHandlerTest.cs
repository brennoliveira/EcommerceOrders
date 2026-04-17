using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Orders.CreateOrder;
using Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace Tests.Unit.Orders
{
    public class CreateOrderHandlerTest
    {
        [Fact]
        public async Task Should_Create_Order_Successfully()
        {
            var respoitoryMock = new Mock<IOrderRepository>();

            var handler = new CreateOrderHandler(respoitoryMock.Object);

            var command = new CreateOrderCommand
            {
                UserId = Guid.NewGuid(),
                Items = new List<CreateOrderItemDto>
                {
                    new() { ProductId = Guid.NewGuid(), Quantity = 2  },
                }
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeEmpty();
            respoitoryMock.Verify(x => x.AddAsync(It.IsAny<Domain.Entities.Order>()), Times.Once);
        }
    }
}
