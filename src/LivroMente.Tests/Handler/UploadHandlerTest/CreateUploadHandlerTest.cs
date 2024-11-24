using LivroMente.API.Commands.UploadCommands;
using LivroMente.API.Handlers;
using LivroMente.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LivroMente.Tests.Handler.UploadHandlerTest
{
    public class CreateUploadHandlerTest
    {
        private readonly Mock<IBlobService> _service;
        private readonly CreateUploadHandler _handler;

        public CreateUploadHandlerTest()
        {
            _service = new Mock<IBlobService>();
            _handler = new CreateUploadHandler(_service.Object);
        }

        [Fact]
        public async void Handler_ReturnUrl_WhenImageIsSave()
        {
            var fileMock = new Mock<IFormFile>();
            var request = new UploadAddCommand(fileMock.Object);

            var uri = new Uri("http://example.com/test.txt");

            _service.Setup(x => x.UploadFileBlobAsyn(
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                )).ReturnsAsync(uri);

            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.Equal(uri.AbsoluteUri, result);
            _service.Verify(service => service.UploadFileBlobAsyn(
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<string>(),
                It.IsAny<string>()
           ), Times.Once);

        }

        [Fact]
        public async void Handler_ReturnNullUrl_WhenImageIsNotSave()
        {
            var fileMock = new Mock<IFormFile>();
            var request = new UploadAddCommand(fileMock.Object);

            var uri = new Uri("http://example.com/test.txt");

            _service.Setup(x => x.UploadFileBlobAsyn(
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                )).ReturnsAsync((Uri)null);

            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.Null(result);
            _service.Verify(service => service.UploadFileBlobAsyn(
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<string>(),
                It.IsAny<string>()
           ), Times.Once);

        }

    }
}
