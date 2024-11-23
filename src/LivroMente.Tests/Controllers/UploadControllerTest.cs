using LivroMente.API.Commands.UploadCommands;
using LivroMente.API.Controllers;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LivroMente.Tests.Controllers
{
    public class UploadControllerTest
    {
        private readonly UploadController _controller;
        private readonly Mock<IBlobService> _service;
        private readonly Mock<IMediator> _mediator;

        public UploadControllerTest()
        {
            _service = new Mock<IBlobService>();
            _mediator = new Mock<IMediator>();
            _controller = new UploadController(_service.Object,_mediator.Object);
        }

        [Fact]
        public async void Get_ShoulReturnNoContent_WhenMediatorIsNull()
        {
            _mediator.Setup(x => x.Send(It.IsAny<UploadGetAllCommand>(), CancellationToken.None)).ReturnsAsync(() => null);

            var result = await _controller.GetAll();

            _mediator.Verify(x => x.Send(It.IsAny<UploadGetAllCommand>(), CancellationToken.None), Times.Once);
        
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Get_ShoulReturnOk_WhenMediatorNotNull()
        {
            var images = new List<string> { "image1.png","image2.png"};
            _mediator.Setup(x => x.Send(It.IsAny<UploadGetAllCommand>(), CancellationToken.None)).ReturnsAsync(images);

            var result = await _controller.GetAll();

            _mediator.Verify(x => x.Send(It.IsAny<UploadGetAllCommand>(), CancellationToken.None), Times.Once);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetById_ShoulReturnNotFound_WhenMediatorIsNull()
        {
            _mediator.Setup(x => x.Send(It.IsAny<UploadGetByNameCommand>(), CancellationToken.None)).ReturnsAsync(() => null);

            var result = await _controller.GetByName("Teste");

            _mediator.Verify(x => x.Send(It.IsAny<UploadGetByNameCommand>(), CancellationToken.None), Times.Once);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetById_ShoulReturnOk_WhenMediatorIsNotNull()
        {
            var image = "Teste.png";
            _mediator.Setup(x => x.Send(It.IsAny<UploadGetByNameCommand>(), CancellationToken.None)).ReturnsAsync(image);

            var result = await _controller.GetByName("Teste");

            _mediator.Verify(x => x.Send(It.IsAny<UploadGetByNameCommand>(), CancellationToken.None), Times.Once);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Post_ShouldReturnBadRequest_WhenMediatorIsNull()
        {
            var file = new Mock<IFormFile>();
            _mediator.Setup(x => x.Send(It.IsAny<UploadAddCommand>(), CancellationToken.None)).ReturnsAsync((string)null);
            var result = await _controller.UploadProfilePicture(file.Object);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Post_ShouldReturnOk_WhenMediatorIsNotNull()
        {
            var file = new Mock<IFormFile>();
            _mediator.Setup(x => x.Send(It.IsAny<UploadAddCommand>(), CancellationToken.None)).ReturnsAsync("image");
            var result = await _controller.UploadProfilePicture(file.Object);
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void Delete_ShouldReturnBadRequest_WhenMediatorIsFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<UploadDeleteCommand>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _controller.DeleteFile("image");
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Delete_ShouldReturnOk_WhenMediatorIsTrue()
        {
            _mediator.Setup(x => x.Send(It.IsAny<UploadDeleteCommand>(), CancellationToken.None)).ReturnsAsync(true);
            var result = await _controller.DeleteFile("image");
            Assert.IsType<OkResult>(result);
        }


    }
}
