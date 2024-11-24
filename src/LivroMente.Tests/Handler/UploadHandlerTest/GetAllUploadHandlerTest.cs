using LivroMente.API.Commands.UploadCommands;
using LivroMente.API.Handlers.UploadHandler;
using LivroMente.Service.Interfaces;
using Moq;
using Xunit;

namespace LivroMente.Tests.Handler.UploadHandlerTest
{
    public class GetAllUploadHandlerTest
    {
        private readonly Mock<IBlobService> _service;
        private readonly GetAllUploadHandler _handler;

        public GetAllUploadHandlerTest()
        {
            _service = new Mock<IBlobService>();
            _handler = new GetAllUploadHandler(_service.Object);
        }
        [Fact]
        public async void Handle_ReturnsListOfBlobs_WhenBlobsExist()
        {
            var blobs = new List<Uri>
            {
                new Uri("http://example.com/blob1"),
                new Uri("http://example.com/blob2")
            };

           
            _service.Setup(x => x.GetFileBlobAsync("livromente"))
                   .Returns(Task.FromResult(blobs.Select(b => b.ToString()).AsEnumerable()));

            var request = new UploadGetAllCommand();
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void Handle_ReturnNull_WhenBlobsNotExist()
        {
            var blobs = new List<Uri>();

            _service.Setup(x => x.GetFileBlobAsync("livromente"))
                   .Returns(Task.FromResult(blobs.Select(b => b.ToString()).AsEnumerable()));

            var request = new UploadGetAllCommand();
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.Empty(result);
        }
    }
}
