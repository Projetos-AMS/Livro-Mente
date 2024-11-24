using LivroMente.API.Commands.UploadCommands;
using LivroMente.API.Handlers.UploadHandler;
using LivroMente.Service.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LivroMente.Tests.Handler.UploadHandlerTest
{
    public class GetByNameUploadHandlerTest
    {
        private readonly Mock<IBlobService> _service;
        private readonly GetByNameUploadHandler _handler;

        public GetByNameUploadHandlerTest()
        {
            _service = new Mock<IBlobService>();
            _handler = new GetByNameUploadHandler(_service.Object);
        }

        [Fact]
        public async void Handler_ReturnFile_WhenFileExist()
        {
            var fileName = "test.txt";
            var uri = new Uri("http://example.com/test.txt");
            _service.Setup(x => x.GetByNameFileBlobAsync("livromente", fileName)).Returns(Task.FromResult(uri.ToString()));

            var request = new UploadGetByNameCommand(fileName);

            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(uri.ToString(), result);
        }

        [Fact]
        public async void Handler_ThrowsArgumentNullException_WhenFileDoesNotExist()
        {
            var fileName = "test.txt";
       
            _service.Setup(x => x.GetByNameFileBlobAsync("livromente", fileName)).Returns(Task.FromResult<string>(null));

            var request = new UploadGetByNameCommand(fileName);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
            Assert.Equal("File not found. (Parameter 'FileName')", exception.Message);
        }
    }
}
