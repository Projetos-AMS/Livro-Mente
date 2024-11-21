using LivroMente.API.Controllers;
using LivroMente.API.ViewModels;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LivroMente.Tests.Controllers
{
    public class RoleControllerTest
    {
        private readonly RoleController _controller;
        private readonly Mock<RoleManager<Role>> _mockRoleManager;
        private readonly Mock<UserManager<User>> _mockUserManager;
        private readonly Mock<IRoleService> _service;

        public RoleControllerTest()
        {
            _mockRoleManager = new Mock<RoleManager<Role>>(
                Mock.Of<IRoleStore<Role>>(), null, null, null, null);
            _mockUserManager = new Mock<UserManager<User>>(
           Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            _service = new Mock<IRoleService>();
            _controller = new RoleController(_mockRoleManager.Object,_mockUserManager.Object,_service.Object);
        }

     
        [Fact]
        public async void GetAll_ShouldReturnOk_WhenListIsNotNull()
        {
            var roles = new List<Role> { new Role { Name = "Admin" }, new Role { Name = "User" } };
            _service.Setup(x => x.GetAll()).ReturnsAsync(roles);
            var result = await _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Role>>(okResult.Value);
            Assert.Equal(roles.Count, returnValue.Count);
        }

        [Fact]
        public async void Post_ShouldReturnBadRequest_WhenResultIsFalse()
        {
            var role = new RoleViewModel { Name = "Admin" };
            _mockRoleManager.Setup(x => x.CreateAsync(It.IsAny<Role>())).ThrowsAsync(new Exception("Error creating role"));

            var result = await _controller.CreateRole(role);
            Assert.IsType<BadRequestObjectResult>(result);

        }

        [Fact]
        public async void Post_ShouldReturnOk_WhenResultIsTrue()
        {
            var role = new RoleViewModel { Name = "Admin" };
            _mockRoleManager.Setup(x => x.CreateAsync(It.IsAny<Role>())).ReturnsAsync(IdentityResult.Success);

            var result = await _controller.CreateRole(role);
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void UpdateUserRole_ShouldReturnNoContent_WhenUserNotFound()
        {
            var userRole = new UpdateUserRoleViewModel { Email = "teste@gmail.com", Role = "Admin", Delete = false };

            _mockUserManager.Setup(x => x.FindByEmailAsync(userRole.Email)).ThrowsAsync(new Exception("Error creating role"));

            var result = await _controller.UpdateUserRoles(userRole);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void UpdateUserRole_ShouldReturnBadRequest_WhenUserNotUpdate()
        {
            var userRole = new UpdateUserRoleViewModel { Email = "teste@gmail.com", Role = "Admin", Delete = false };

            _mockUserManager.Setup(x => x.FindByEmailAsync(userRole.Email)).ReturnsAsync((User)null);

            var result = await _controller.UpdateUserRoles(userRole);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void UpdateUserRole_ShouldReturnOk_WhenUserUpdate()
        {
            var userRole = new UpdateUserRoleViewModel { Email = "teste@gmail.com", Role = "Admin", Delete = false };
            var user = new User { Email = userRole.Email };

            _mockUserManager.Setup(x => x.FindByEmailAsync(userRole.Email)).ReturnsAsync(user);
            _mockUserManager.Setup(x => x.AddToRoleAsync(user,userRole.Role)).ReturnsAsync(IdentityResult.Success);

            var result = await _controller.UpdateUserRoles(userRole);
            Assert.IsType<OkResult>(result);
        }


    }
}
