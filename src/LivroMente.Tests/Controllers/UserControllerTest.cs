using LivroMente.API.Commands.UserCommands;
using LivroMente.API.Controllers;
using LivroMente.API.Requests;
using LivroMente.Service.Dtos;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;

namespace LivroMente.Tests.Controllers
{
    public class UserControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IUserService> _service;
        private readonly UserController _controller;

        public UserControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _service = new Mock<IUserService>();
            _controller = new UserController(_mediator.Object,_service.Object);
        }

        [Fact]
        public async void GetUserRoles_ShoulReturnNoContent_WhenListIsNull()
        {
            var mockEmptyList = new List<UserDto>();
            _service.Setup(x => x.GetUserRolesInclude()).ReturnsAsync(mockEmptyList);
            var result = await _controller.GetUserRoles();
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void GetUserRoles_ShoulReturnOk_WhenListIsNotNull()
        {
            var mockUsers = new List<UserDto>
        {
            new UserDto
            {
                Id = "1",
                CompleteName = "User One",
                Email = "userone@example.com",
                IsActive = true,
                Roles = new List<string> { "admin", "user" }
            },
            new UserDto
            {
                Id = "2",
                CompleteName = "User Two",
                Email = "usertwo@example.com",
                IsActive = true,
                Roles = new List<string> { "user" }
            }
        };
            _service.Setup(x => x.GetUserRolesInclude()).ReturnsAsync(mockUsers);
            var result = await _controller.GetUserRoles();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetUserById_ShoulReturnNoContent_WhenUserNotFound()
        {
            _service.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(() => null);
            var result = await _controller.GetUserbyId(Guid.NewGuid().ToString());
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void GetUserById_ShoulReturnOk_WhenUserIsFound()
        {
            
            var user = new UserDto
            {
                Id = "1",
                CompleteName = "User One",
                Email = "userone@example.com",
                IsActive = true,
                Roles = new List<string> { "admin", "user" }
            };
            _service.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            var result = await _controller.GetUserbyId(Guid.NewGuid().ToString());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Register_ShouldReturnUnauthorized_WhenMediatorIsFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<RegisterCommand>(), CancellationToken.None)).ReturnsAsync((string) null);
            var result = await _controller.Register(new RegisterRequest());
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async void Register_ShouldReturnOk_WhenMediatorIsTrue()
        {
            var register = new RegisterRequest { CompleteName = "Teste do teste", Email = "teste@gmail.com", Password = "Senha12@", ConfirmPassword ="Senha12@", Role ="Admin" };
            _mediator.Setup(x => x.Send(It.IsAny<RegisterCommand>(), CancellationToken.None)).ReturnsAsync("fake_token");
            var result = await _controller.Register(register);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Login_ShouldReturnUnauthorized_WhenMediatorIsFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<LoginCommand>(),CancellationToken.None)).ReturnsAsync((string) null);
            var result = await _controller.Login(new LoginRequest());
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async void Login_ShouldReturnOk_WhenMediatorIsTrue()
        {
            var request = new LoginRequest { Email = "teste@gmail.com", Password = "Senha12@" };
            _mediator.Setup(x => x.Send(It.IsAny<LoginCommand>(), CancellationToken.None)).ReturnsAsync("fake_token");
            var result = await _controller.Login(request);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Delete_ShouldReturnOk_WhenMediatorIsTrue()
        {
            var id = Guid.NewGuid();
            _mediator.Setup(m => m.Send(It.IsAny<UserDeleteCommand>(), default))
                         .ReturnsAsync(true);

            var result = await _controller.Delete(id);

            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }
    }
}
