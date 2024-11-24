using LivroMente.API.Commands.AdminCommands;
using LivroMente.API.Handlers.AdminHandler;
using LivroMente.Domain.Models.OrderDetailsModel;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Service.Interfaces;
using Moq;
using Xunit;

namespace LivroMente.Tests.Handler.AdminHandlerTest
{
    public class GetAllOorderHandlerTest
    {
        private readonly Mock<IOrderService> _service;
        private readonly GetAllOrdersHandler _handler;

        public GetAllOorderHandlerTest()
        {
            _service = new Mock<IOrderService>();
            _handler = new GetAllOrdersHandler(_service.Object);
        }

        [Fact]
        public async void Handler_ReturnAllOrdersWithTotal()
        {
            var orderDetails = new List<OrderDetails>
            {
                new OrderDetails { OrderId = "1234", BookId = "567", Amount = 10, ValueUni = 10 }
            };

            var orders = new List<Order>
            {
                new Order("123", DateTime.Now, 10, "Venda", orderDetails),
                new Order("123", DateTime.Now, 10, "Venda", orderDetails)
            };
                
            var request = new AdminAllOrdersCommand();

            _service.Setup(x => x.GetAll()).ReturnsAsync(orders);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.Equal(2, result.Count);
            Assert.Equal(20, result.First().Total);
        }
    }
}
