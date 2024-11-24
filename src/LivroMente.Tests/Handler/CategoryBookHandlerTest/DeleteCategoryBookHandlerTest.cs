using LivroMente.API.Commands.CategoryBookCommands;
using LivroMente.API.Handlers.CategoryBookHandler;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Service.Interfaces;
using Moq;
using Xunit;

namespace LivroMente.Tests.Handler.CategoryBookHandlerTest
{
    public class DeleteCategoryBookHandlerTest
    {
        private readonly Mock<ICategoryBookService> _service;
        private readonly DeleteCategoryBookHandler _handler;

        public DeleteCategoryBookHandlerTest()
        {
            _service = new Mock<ICategoryBookService>();
            _handler = new DeleteCategoryBookHandler(_service.Object);
        }

        [Fact]
        public async void Handler_ReturnFalse_WhenCategoryIsNotDelete()
        {
            var request = new CategoryBookDeleteCommand(Guid.NewGuid().ToString());
            var category = new CategoryBook("Teste",true);

            _service.Setup(x => x.GetById(request.Id)).ReturnsAsync(category);
            _service.Setup(x => x.Delete(category.Id)).ReturnsAsync(false);

            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.False(result);

        }

        [Fact]
        public async void Handler_ReturnTrue_WhenCategoryIsDelete()
        {
            var request = new CategoryBookDeleteCommand(Guid.NewGuid().ToString());
            var category = new CategoryBook("Teste", true);

            _service.Setup(x => x.GetById(request.Id)).ReturnsAsync(category);
            _service.Setup(x => x.Delete(category.Id)).ReturnsAsync(true);

            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.True(result);

        }
    }
}
