using LivroMente.API.Commands.OrderCommands;
using LivroMente.API.Handlers.OrderHandler;
using LivroMente.API.Requests;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Service.Dtos;
using LivroMente.Service.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LivroMente.Tests.Handler.OrderHandlerTest
{
    public class CreateOrderHandlerTest
    {
        private readonly Mock<IOrderService> _service;
        private readonly CreateOrderHandler _handler;

        public CreateOrderHandlerTest()
        {
            _service = new Mock<IOrderService>();
            _handler = new CreateOrderHandler(_service.Object);
        }

        [Fact]
        public async void Handler_ReturnFalse_WhenOrderNotCreate()
        {
            var orderDetails = new List<OrderDetailsRequest>
            {
                new OrderDetailsRequest { OrderId = "1234", BookId = "567", Amount = 10, ValueUni = 10 }
            };

            var request = new OrderAddCommand
            {
                OrderRequest = new OrderRequest { UserId = "123", Date = new DateTime(), ValueTotal = 10, Status = "Venda", OrderDetails = orderDetails }
            };

            _service.Setup(x => x.Add(It.IsAny<Order>())).ReturnsAsync(false);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.False(result);
        }

        [Fact]
        public async void Handler_ReturnTrue_WhenOrderCreate()
        {
            var orderDetails = new List<OrderDetailsRequest>
            {
                new OrderDetailsRequest { OrderId = "1234", BookId = "567", Amount = 10, ValueUni = 10 }
            };

            var request = new OrderAddCommand
            {
                OrderRequest = new OrderRequest { UserId = "123", Date = new DateTime(), ValueTotal = 10, Status = "Venda", OrderDetails = orderDetails }
            };

            _service.Setup(x => x.Add(It.IsAny<Order>())).ReturnsAsync(true);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
    }
}
