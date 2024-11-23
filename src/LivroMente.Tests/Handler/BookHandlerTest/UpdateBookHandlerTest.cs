
using LivroMente.API.Commands.BookCommands;
using LivroMente.API.Handlers.BookHandler;
using LivroMente.API.Requests;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Service.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LivroMente.Tests.Handler.BookHandlerTest
{
    public class UpdateBookHandlerTest
    {
        private readonly Mock<IBookService> _service;
        private readonly UpdateBookHandler _handler;

        public UpdateBookHandlerTest()
        {
            _service = new Mock<IBookService>();
            _handler = new UpdateBookHandler(_service.Object);
        }

        [Fact]
        public async void Handle_ReturnFalse_WhenBookIsNotUpdate()
        {
            var id = Guid.NewGuid().ToString();
            var request = new BookUpdateCommand(id, new BookRequest
            {
                Title = "Updated Title",
                Author = "Updated Author",
                Synopsis = "Updated Synopsis",
                Quantity = 5,
                Pages = 300,
                PublishingCompany = "Updated Publisher",
                Isbn = "0987654321",
                Value = 39.99,
                Language = "Portuguese",
                Classification = 12,
                IsActive = true,
                CategoryId = Guid.NewGuid().ToString(),
                UrlBook = "http://example.com/updatedbook",
                UrlImg = "http://example.com/updatedimg"
            });

            var book = new Book("Original Title", "Original Author", "Original Synopsis", 10, 200, "Original Publisher", "1234567890", 29.99, "English", 12, true, Guid.NewGuid().ToString(), "http://example.com/book", "http://example.com/img");
            

            _service.Setup(service => service.GetById(request.Id)).ReturnsAsync(book);
            _service.Setup(service => service.Update(book.Id)).ReturnsAsync(false);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result);

        }

        [Fact]
        public async void Handle_ReturnTrue_WhenBookIsUpdate()
        {
            var id = Guid.NewGuid().ToString();
            var request = new BookUpdateCommand(id, new BookRequest
            {
                Title = "Updated Title",
                Author = "Updated Author",
                Synopsis = "Updated Synopsis",
                Quantity = 5,
                Pages = 300,
                PublishingCompany = "Updated Publisher",
                Isbn = "0987654321",
                Value = 39.99,
                Language = "Portuguese",
                Classification = 12,
                IsActive = true,
                CategoryId = Guid.NewGuid().ToString(),
                UrlBook = "http://example.com/updatedbook",
                UrlImg = "http://example.com/updatedimg"
            });

            var book = new Book("Original Title", "Original Author", "Original Synopsis", 10, 200, "Original Publisher", "1234567890", 29.99, "English", 12, true, Guid.NewGuid().ToString(), "http://example.com/book", "http://example.com/img");


            _service.Setup(service => service.GetById(request.Id)).ReturnsAsync(book);
            _service.Setup(service => service.Update(book.Id)).ReturnsAsync(true);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result);

        }
    }
}
