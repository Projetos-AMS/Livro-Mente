using LivroMente.API.Commands.UserCommands;
using LivroMente.API.Handlers.UserHandler;
using LivroMente.Service.Interfaces;
using Microsoft.OpenApi.Validations;
using Moq;
using Xunit;

namespace LivroMente.Tests.Handler.UserHandlerTest
{
    public class UserDeleteHandlerTest
    {
        private readonly Mock<IUserService> _service;
        private readonly UserDeleteHandler _handler;

        public UserDeleteHandlerTest()
        {
            _service = new Mock<IUserService>();
            _handler = new UserDeleteHandler(_service.Object);
        }

        [Fact]
        public async void Handle_CallsDeleteUserAsync_WithCorrectParameters()
        {
            var id = Guid.NewGuid();
            var command = new UserDeleteCommand(id);

            _service.Setup(x => x.DeleteUserAsync(id)).Returns(Task.FromResult(true));
            await _handler.Handle(command, CancellationToken.None);

            _service.Verify(x => x.DeleteUserAsync(id), Times.Once);
        }
    }
}
