using LivroMente.API.Commands.OrderCommands;
using LivroMente.API.Controllers;
using LivroMente.Service.Dtos;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LivroMente.Tests.Controllers
{
    public class OrderControllerTest
    {
        private readonly OrderController _controller;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IOrderService> _service;

        public OrderControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _service = new Mock<IOrderService>();
            _controller = new OrderController(_mediator.Object, _service.Object);
        }

        [Fact]
        public async void  GetAll_ShouldReturnNoContent_WhenListIsNull()
        {
            _service.Setup(x => x.GetOrder()).Returns(() => null);
            var result = await _controller.GetAll();
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenListIsNotNull()
        {
            var orderDetails = new List<OrderDetailsDto>
            {
                new OrderDetailsDto{BookId = "123",Amount=10,ValueUni= 12}
            };

            var orders = new List<OrderDto>
            {
                new OrderDto{UserId = "userId1", Date= DateTime.Now, ValueTotal= 20.5f, Status ="Pending",OrderDetails= orderDetails }
            };
           
            _service.Setup(x => x.GetOrder()).Returns(orders);
            var result = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNotFound_WhenOrderNotFound()
        {
            _service.Setup(x => x.GetOrder()).Returns(() => null);
            var result = await _controller.GetById(Guid.NewGuid().ToString());
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Post_ShouldReturnBadRequest_WhenMeditorReturnFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<OrderAddCommand>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _controller.Post(new OrderAddCommand());
            _mediator.Verify(x => x.Send(It.IsAny<OrderAddCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Post_ShouldReturnCreated_WhenMeditorReturnTrue()
        {
            _mediator.Setup(x => x.Send(It.IsAny<OrderAddCommand>(), CancellationToken.None)).ReturnsAsync(true);
            var result = await _controller.Post(new OrderAddCommand());
            _mediator.Verify(x => x.Send(It.IsAny<OrderAddCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async void Delete_ShouldReturnNotFound_WhenMediatorrReturnNull()
        {
            _mediator.Setup(x => x.Send(It.IsAny<OrderDisableCommand>(), CancellationToken.None)).ReturnsAsync((bool?)null);
            var result = await _controller.Delete(Guid.NewGuid().ToString());
            _mediator.Verify(x => x.Send(It.IsAny<OrderDisableCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Delete_ShouldReturnBadRequest_WhenMediatorrReturnFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<OrderDisableCommand>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _controller.Delete(Guid.NewGuid().ToString());
            _mediator.Verify(x => x.Send(It.IsAny<OrderDisableCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Delete_ShouldReturnOk_WhenMediatorrReturnTrue()
        {
            _mediator.Setup(x => x.Send(It.IsAny<OrderDisableCommand>(), CancellationToken.None)).ReturnsAsync(true);
            var result = await _controller.Delete(Guid.NewGuid().ToString());
            _mediator.Verify(x => x.Send(It.IsAny<OrderDisableCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<OkResult>(result);
        }
    }
}