using LivroMente.API.Commands.BookCommands;
using LivroMente.API.Controllers;
using LivroMente.API.Requests;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LivroMente.Tests.Controllers
{
    public class BookControllerTest
    {
        private readonly BookController _controller;
        private readonly Mock<IBookService> _service;
        private readonly Mock<IMediator> _mediator;

        public BookControllerTest()
        {
            _service = new Mock<IBookService>();
            _mediator = new Mock<IMediator>();
            _controller = new BookController(_service.Object,_mediator.Object);
        }

        [Fact]
        public async  void GetAll_ShouldReturnNoContent_WhenListIsNull()
        {
            _service.Setup(x => x.GetAll()).ReturnsAsync(() => null);
            var result = await _controller.GetAll();
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnOk_WhenListIsNotNull()
        {
            var books = new List<Book>
            {
                 new Book(
                    title: "The Great Gatsby",
                    author: "F. Scott Fitzgerald",
                    synopsis: "A story about the American dream, love, and tragedy.",
                    quantity: 100,
                    pages: 180,
                    publishingCompany: "Scribner",
                    isbn: "9780743273565",
                    value: 10.99,
                    language: "English",
                    classification: 5,
                    isActive: true,
                    categoryId: "1",
                    urlBook: "https://www.example.com/greatgatsby",
                    urlImg: "https://www.example.com/greatgatsby.jpg"
                ),
                new Book(
                    title: "1984",
                    author: "George Orwell",
                    synopsis: "A dystopian novel about totalitarianism and surveillance.",
                    quantity: 150,
                    pages: 328,
                    publishingCompany: "Secker & Warburg",
                    isbn: "9780451524935",
                    value: 8.99,
                    language: "English",
                    classification: 5,
                    isActive: true,
                    categoryId: "2",
                    urlBook: "https://www.example.com/1984",
                    urlImg: "https://www.example.com/1984.jpg"
                ),
            };
            _service.Setup(x => x.GetAll()).ReturnsAsync(books);
            var result = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(2, books.Count);
        }

        [Fact]
        public async void GetById_ShouldRetuenNotFound_WhenBookNotFound()
        {
            _service.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            var result = await _controller.GetById(Guid.NewGuid().ToString());
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetById_ShouldRetuenOk_WhenBookFound()
        {
            var id = "123cd";
            var book = new Book(
                    title: "1984",
                    author: "George Orwell",
                    synopsis: "A dystopian novel about totalitarianism and surveillance.",
                    quantity: 150,
                    pages: 328,
                    publishingCompany: "Secker & Warburg",
                    isbn: "9780451524935",
                    value: 8.99,
                    language: "English",
                    classification: 5,
                    isActive: true,
                    categoryId: "2",
                    urlBook: "https://www.example.com/1984",
                    urlImg: "https://www.example.com/1984.jpg"
                );

            _service.Setup(x => x.GetById(id)).ReturnsAsync(book);
            var result = await _controller.GetById(id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Post_ShouldReturnBadRequest_WhenMediatorReturnFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<BookAddCommand>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _controller.Post(new BookAddCommand());
            _mediator.Verify(x => x.Send(It.IsAny<BookAddCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Post_ShouldReturnOk_WhenMediatorReturnTrue()
        {
            _mediator.Setup(x => x.Send(It.IsAny<BookAddCommand>(), CancellationToken.None)).ReturnsAsync(true);
            var result = await _controller.Post(new BookAddCommand());
            _mediator.Verify(x => x.Send(It.IsAny<BookAddCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async void Put_ShouldReturnNotFound_WhenMediatorReturnNull()
        {
            _mediator.Setup(x => x.Send(It.IsAny<BookUpdateCommand>(), CancellationToken.None)).ReturnsAsync((bool?)null);
            var result = await _controller.Put(Guid.NewGuid().ToString(),new BookRequest());
            _mediator.Verify(x => x.Send(It.IsAny<BookUpdateCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Put_ShouldReturnBadRequest_WhenMediatorReturnFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<BookUpdateCommand>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _controller.Put(Guid.NewGuid().ToString(), new BookRequest());
            _mediator.Verify(x => x.Send(It.IsAny<BookUpdateCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Put_ShouldReturnOk_WhenMediatorReturnTrue()
        {
            _mediator.Setup(x => x.Send(It.IsAny<BookUpdateCommand>(), CancellationToken.None)).ReturnsAsync(true);
            var result = await _controller.Put(Guid.NewGuid().ToString(), new BookRequest());
            _mediator.Verify(x => x.Send(It.IsAny<BookUpdateCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void Delete_ShouldReturnNotFound_WhenMediatorReturnNull()
        {
            _mediator.Setup(x => x.Send(It.IsAny<BookDeleteCommand>(), CancellationToken.None)).ReturnsAsync((bool?)null);
            var result = await _controller.Delete(Guid.NewGuid().ToString());
            _mediator.Verify(x => x.Send(It.IsAny<BookDeleteCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Delete_ShouldReturnBadRequest_WhenMediatorReturnFalse()
        {
            _mediator.Setup(x => x.Send(It.IsAny<BookDeleteCommand>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _controller.Delete(Guid.NewGuid().ToString());
            _mediator.Verify(x => x.Send(It.IsAny<BookDeleteCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Delete_ShouldReturnOk_WhenMediatorReturnTrue()
        {
            _mediator.Setup(x => x.Send(It.IsAny<BookDeleteCommand>(), CancellationToken.None)).ReturnsAsync(true);
            var result = await _controller.Delete(Guid.NewGuid().ToString());
            _mediator.Verify(x => x.Send(It.IsAny<BookDeleteCommand>(), CancellationToken.None), Times.Once);
            Assert.IsType<OkResult>(result);
        }

    }
}