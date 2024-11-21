using LivroMente.API.Commands.AdminCommands;
using LivroMente.API.Controllers;
using LivroMente.API.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LivroMente.Tests.Controllers
{
    public class AdminControllerTest
    {
        private readonly AdminController _controller;
        private readonly Mock<IMediator> _mediator;

        public AdminControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _controller = new AdminController(_mediator.Object);
        }

        [Fact]
        public async void GetAllOrders_ShouldReturnNoContent_WhenMediatorReturnNull()
        {
            _mediator.Setup(x => x.Send(It.IsAny<AdminAllOrdersCommand>(), CancellationToken.None)).ReturnsAsync(() => null);
            var result = await _controller.GetAllOrders();
            _mediator.Verify(x => x.Send(It.IsAny<AdminAllOrdersCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void GetAllOrders_ShouldReturnOk_WhenMediatorReturnList()
        {
            List<AllOrders> orders = new List<AllOrders>
            {
                new AllOrders
                {
                    UserId = "user123",
                    Date = new DateTime(2024, 10, 1),
                    ValueTotal = 100.50f,
                    Total = 120.50f
                },
                new AllOrders
                {
                    UserId = "user456",
                    Date = new DateTime(2024, 10, 2),
                    ValueTotal = 250.75f,
                    Total = 270.75f
                },
            };

            _mediator.Setup(x => x.Send(It.IsAny<AdminAllOrdersCommand>(), CancellationToken.None)).ReturnsAsync(orders);
            var result = await _controller.GetAllOrders();
            _mediator.Verify(x => x.Send(It.IsAny<AdminAllOrdersCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(2, orders.Count);
        }
    }
}