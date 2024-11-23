using LivroMente.API.Commands.BookCommands;
using LivroMente.API.Handlers.BookHandler;
using LivroMente.API.Requests;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Service.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LivroMente.Tests.Handler.BookHandlerTest
{
    public class CreateBookHandlerTest
    {
        private readonly Mock<IBookService> _service;
        private readonly CreateBookHandler _handler;

        public CreateBookHandlerTest()
        {
            _service = new Mock<IBookService>();
            _handler = new CreateBookHandler(_service.Object);
        }

        [Fact]
        public async Task Handle_ReturnsFalse_WhenBookIsNotAdded()
        {
          
            var request = new BookAddCommand
            {
                BookRequest = new BookRequest
                {
                    Title = "Test Title",
                    Author = "Test Author",
                    Synopsis = "Test Synopsis",
                    Quantity = 10,
                    Pages = 200,
                    PublishingCompany = "Test Publisher",
                    Isbn = "1234567890",
                    Value = 29.99,
                    Language = "English",
                    Classification = 12,
                    IsActive = true,
                    CategoryId = Guid.NewGuid().ToString(),
                    UrlBook = "http://example.com/book",
                    UrlImg = "http://example.com/img"
                }
            };

            _service.Setup(service => service.Add(It.IsAny<Book>())).ReturnsAsync(false);

            
            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result);
        }

        [Fact]
        public async Task Handle_ReturnsTrue_WhenBookIsAdded()
        {

            var request = new BookAddCommand
            {
                BookRequest = new BookRequest
                {
                    Title = "Test Title",
                    Author = "Test Author",
                    Synopsis = "Test Synopsis",
                    Quantity = 10,
                    Pages = 200,
                    PublishingCompany = "Test Publisher",
                    Isbn = "1234567890",
                    Value = 29.99,
                    Language = "English",
                    Classification = 12,
                    IsActive = true,
                    CategoryId = Guid.NewGuid().ToString(),
                    UrlBook = "http://example.com/book",
                    UrlImg = "http://example.com/img"
                }
            };

            _service.Setup(service => service.Add(It.IsAny<Book>())).ReturnsAsync(true);


            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result);
        }
    }
}
