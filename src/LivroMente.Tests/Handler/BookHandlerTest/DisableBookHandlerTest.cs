using LivroMente.API.Commands.BookCommands;
using LivroMente.API.Handlers.BookHandler;
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
    public class DisableBookHandlerTest
    {
        private readonly Mock<IBookService> _service;
        private readonly DisableBookHandler _handler;

        public DisableBookHandlerTest()
        {
            _service = new Mock<IBookService>();
            _handler = new DisableBookHandler(_service.Object);
        }

        [Fact]
        public async void Handler_ReturnFalse_WhenBookIsNotDisable()
        {
            var request = new BookDisableCommand(Guid.NewGuid().ToString());
            var book = new Book("Original Title", "Original Author", "Original Synopsis", 10, 200, "Original Publisher", "1234567890", 29.99, "English", 12, true, "123", "http://example.com/book", "http://example.com/img");

            _service.Setup(service => service.GetById(request.Id)).ReturnsAsync(()=> null);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.False(result);
        }

        [Fact]
        public async Task Handler_ReturnTrue_WhenBookIsDisable()
        {
            var request = new BookDisableCommand(Guid.NewGuid().ToString());
            var book = new Book("Original Title", "Original Author", "Original Synopsis", 10, 200, "Original Publisher", "1234567890", 29.99, "English", 12, true, "123", "http://example.com/book", "http://example.com/img");
           
            _service.Setup(service => service.GetById(request.Id)).ReturnsAsync(book);
            
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
    }
}
