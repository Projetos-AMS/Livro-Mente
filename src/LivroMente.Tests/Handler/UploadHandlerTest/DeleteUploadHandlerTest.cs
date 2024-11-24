using LivroMente.API.Commands.UploadCommands;
using LivroMente.API.Handlers.UploadHandler;
using LivroMente.Service.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LivroMente.Tests.Handler.UploadHandlerTest
{
    public class DeleteUploadHandlerTest
    {
        private readonly Mock<IBlobService> _service;
        private readonly DeleteUploadHandler _handler;

        public DeleteUploadHandlerTest()
        {
            _service = new Mock<IBlobService>();
            _handler = new DeleteUploadHandler(_service.Object);
        }

        [Fact]
        public async void Handle_ReturnsTrue_WhenFileIsDeleted()
        {
            var fileName = "test.txt";
            var uri = new Uri("http://example.com/test.txt");

            _service.Setup(x => x.GetByNameFileBlobAsync("livromente", fileName)).Returns(Task.FromResult(uri.ToString()));
            _service.Setup(x => x.DeleteBlobAsync("livromente", fileName)).Returns(Task.CompletedTask);

            var request = new UploadDeleteCommand(fileName);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }

        [Fact]
        public async void Handle_ReturnsFalse_WhenFileIsNotDeleted()
        {
            var fileName = "test.txt";

            _service.Setup(x => x.GetByNameFileBlobAsync("livromente", fileName)).Returns(Task.FromResult<string>(null));

            var request = new UploadDeleteCommand(fileName);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.False(result);
        }
    }
}
