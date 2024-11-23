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
    public class DeleteBookHandlerTest
    {
        private readonly Mock<IBookService> _service;
        private readonly DeleteBookHandler _handler;

        public DeleteBookHandlerTest()
        {
            _service = new Mock<IBookService>();
            _handler = new DeleteBookHandler(_service.Object);
        }

        [Fact]
        public async void Handle_ReturnFalse_WhenBookIsnotDelete()
        {
            var request = new BookDeleteCommand(Guid.NewGuid().ToString());
            _service.Setup(x => x.Delete(Guid.NewGuid().ToString())).ReturnsAsync(false);
            var result = await _handler.Handle(request,CancellationToken.None);
            Assert.False(result);
        }

        // [Fact]
        // public async void Handle_ReturnTrue_WhenBookIsDelete()
        // {
        //     var id = Guid.NewGuid().ToString();
        //     var book = new Book("Title", "Author", "Synopsis", 10, 200, "Publisher", "1234567890", 29.99, "Language", 12, true, Guid.NewGuid().ToString(), "http://example.com/book", "http://example.com/img");
           

        //     _service.Setup(service => service.GetById(id)).ReturnsAsync(book);
        //     _service.Setup(service => service.Delete(id)).ReturnsAsync(true);

        //     var request = new BookDeleteCommand(id);
        //     var result = await _handler.Handle(request, CancellationToken.None);
        //     Assert.True(result);
        // }
    }
}
