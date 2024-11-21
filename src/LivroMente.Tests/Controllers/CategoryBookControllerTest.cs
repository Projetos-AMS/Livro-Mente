using LivroMente.API.Commands.CategoryBookCommands;
using LivroMente.API.Controllers;
using LivroMente.API.Requests;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LivroMente.Tests.Controllers
{
    public class CategoryBookControllerTest
    {
        private readonly CategoryBookController _controller;
        private readonly Mock<ICategoryBookService> _service;
        private readonly Mock<IMediator> _mediator;

        public CategoryBookControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _service = new Mock<ICategoryBookService>();
            _controller = new CategoryBookController(_service.Object, _mediator.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnNoContent_WhenListIsNull()
        {
            _service.Setup(x => x.GetAll()).ReturnsAsync(() => null);
            var result = await _controller.GetAll();
            Assert.IsType<NoContentResult>(result);

        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenListIsNull()
        {
            var categories = new List<CategoryBook>
            {
                new CategoryBook("Comédia",true),
                new CategoryBook("Romance",true)
            };

            _service.Setup(x => x.GetAll()).ReturnsAsync(categories);
            var result = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(2, categories.Count);
        }

        [Fact]
        public async void GetById_ShouldReturnNoContent_WhenCategoryNotFound()
        {
            _service.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            var result = await _controller.GetById("123de445c");
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnOk_WhenCategoryFound()
        {
            var id = "123cd";
            var category = new CategoryBook("Comédia", true);

            _service.Setup(x => x.GetById(id)).ReturnsAsync(category);
            var result = await _controller.GetById(id);
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void PostCategory_ShouldReturnBadRequest_WhenMediatorIsFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<CategoryBookAddCommand>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _controller.Post(new CategoryBookAddCommand());
            _mediator.Verify(x => x.Send(It.IsAny<CategoryBookAddCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<BadRequestResult>(result);

        }

        [Fact]
        public async void PostCategory_ShouldReturnCreated_WhenMediatorIsTrue()
        {
            _mediator.Setup(x => x.Send(It.IsAny<CategoryBookAddCommand>(), CancellationToken.None)).ReturnsAsync(true);
            var result = await _controller.Post(new CategoryBookAddCommand());
            _mediator.Verify(x => x.Send(It.IsAny<CategoryBookAddCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async void PutCategory_ShouldReturnNotFound_WhenMediatorReturnNull()
        {
            _mediator.Setup(x => x.Send(It.IsAny<CategoryBookUpdateCommand>(), CancellationToken.None)).ReturnsAsync((bool?)null);
            var result = await _controller.Put(Guid.NewGuid().ToString(), new CategoryBookRequest());
            _mediator.Verify(x => x.Send(It.IsAny<CategoryBookUpdateCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void PutCategory_ShouldReturnBadRequest_WhenMediatorReturnFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<CategoryBookUpdateCommand>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _controller.Put(Guid.NewGuid().ToString(), new CategoryBookRequest());
            _mediator.Verify(x => x.Send(It.IsAny<CategoryBookUpdateCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void PutCategory_ShouldReturnOk_WhenMediatorReturnTrue()
        {
            _mediator.Setup(x => x.Send(It.IsAny<CategoryBookUpdateCommand>(), CancellationToken.None)).ReturnsAsync(true);
            var result = await _controller.Put(Guid.NewGuid().ToString(), new CategoryBookRequest());
            _mediator.Verify(x => x.Send(It.IsAny<CategoryBookUpdateCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnNotFound_WhenMediatorReturnNull()
        {
            _mediator.Setup(x => x.Send(It.IsAny<CategoryBookDeleteCommand>(), CancellationToken.None)).ReturnsAsync((bool?)null);
            var result = await _controller.Delete(Guid.NewGuid().ToString());
            _mediator.Verify(x => x.Send(It.IsAny<CategoryBookDeleteCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnBadRequest_WhenMediatorReturnFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<CategoryBookDeleteCommand>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _controller.Delete(Guid.NewGuid().ToString());
            _mediator.Verify(x => x.Send(It.IsAny<CategoryBookDeleteCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnTrue_WhenMediatorReturnTrue()
        {
            _mediator.Setup(x => x.Send(It.IsAny<CategoryBookDeleteCommand>(), CancellationToken.None)).ReturnsAsync(true);
            var result = await _controller.Delete(Guid.NewGuid().ToString());
            _mediator.Verify(x => x.Send(It.IsAny<CategoryBookDeleteCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<OkResult>(result);
        }







    }
}