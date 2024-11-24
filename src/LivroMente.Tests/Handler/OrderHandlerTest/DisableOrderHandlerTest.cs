using LivroMente.API.Commands.OrderCommands;
using LivroMente.API.Handlers.OrderHandler;
using LivroMente.API.Requests;
using LivroMente.Domain.Models.OrderDetailsModel;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Service.Interfaces;
using Moq;
using Xunit;

namespace LivroMente.Tests.Handler.OrderHandlerTest
{
    public class DisableOrderHandlerTest
    {
        private readonly Mock<IOrderService> _service;
        private readonly DisableOrderHandler _handler;

        public DisableOrderHandlerTest()
        {
            _service = new Mock<IOrderService>();
            _handler = new DisableOrderHandler(_service.Object);
        }

        [Fact]
        public async void Handler_ReturnFalse_WhenOrderIsNotDisable()
        {
            var request = new OrderDisableCommand(Guid.NewGuid().ToString());
           
            _service.Setup(x => x.GetById(request.Id)).ReturnsAsync(() => null);
            _service.Setup(x => x.Save()).ReturnsAsync(false);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.False(result);
        }

        [Fact]
        public async void Handler_ReturnTrue_WhenOrderIsDisable()
        {
            var orderDetails = new List<OrderDetails>
            {
                new OrderDetails { OrderId = "1234", BookId = "567", Amount = 10, ValueUni = 10 }
            };
            var request = new OrderDisableCommand(Guid.NewGuid().ToString());
            var order = new Order("123", DateTime.Now, 10, "Venda", orderDetails);

            _service.Setup(x => x.GetById(request.Id)).ReturnsAsync(order);
            _service.Setup(x => x.Save()).ReturnsAsync(true);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
    }
}
