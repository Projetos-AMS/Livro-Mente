using LivroMente.API.Commands.UserCommands;
using LivroMente.API.Handlers.UserHandler;
using LivroMente.API.Requests;
using LivroMente.Service.Interfaces;
using Moq;
using Xunit;

namespace LivroMente.Tests.Handler.UserHandlerTest
{
    public class LoginHandlerTest
    {
        private readonly Mock<IUserService> _service;
        private readonly LoginHandler _handler;

        public LoginHandlerTest()
        {
            _service = new Mock<IUserService>();
            _handler = new LoginHandler(_service.Object);
        }

        [Fact]
        public async void Handle_CallsLoginAsync_WithCorrectParameters()
        {
            var login = new LoginRequest { Email = "teste@gmail.com", Password = "Teste12@" };
            var command = new LoginCommand(login);


            _service.Setup(x => x.LoginAsync(login.Email, login.Password)).Returns(Task.FromResult("Success"));
            await _handler.Handle(command, CancellationToken.None);
            _service.Verify(x => x.LoginAsync(login.Email, login.Password), Times.Once);
        }
    }
}
