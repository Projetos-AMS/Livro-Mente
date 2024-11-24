using LivroMente.API.Commands.UserCommands;
using LivroMente.API.Handlers.UserHandler;
using LivroMente.API.Requests;
using LivroMente.Service.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LivroMente.Tests.Handler.UserHandlerTest
{
    public class RegisterHandlerTest
    {
        private readonly Mock<IUserService> _service;
        private readonly RegisterHandler _handler;

        public RegisterHandlerTest()
        {
            _service = new Mock<IUserService>();
            _handler = new RegisterHandler(_service.Object);
        }

        [Fact]
        public async void Handle_RegisterAsync_WithCorrectParameters()
        {
            var register = new RegisterRequest
            {
                CompleteName = "Teste",
                Email = "teste@gmail.com",
                Password = "Teste12@",
                ConfirmPassword = "Teste12@",
                Role = "admin"
            };

            var command = new RegisterCommand(register);
            _service.Setup(x => x.RegisterAsync(register.CompleteName, register.Email, register.Role, 
                register.Password)).Returns(Task.FromResult("Sucess"));

            await _handler.Handle(command, CancellationToken.None);

            _service.Verify(x => x.RegisterAsync(register.CompleteName, register.Email, register.Role,
               register.Password), Times.Once);

        }
    }
}
