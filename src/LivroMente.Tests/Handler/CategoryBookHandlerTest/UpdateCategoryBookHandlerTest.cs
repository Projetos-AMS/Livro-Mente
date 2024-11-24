using LivroMente.API.Commands.CategoryBookCommands;
using LivroMente.API.Handlers.CategoryBookHandler;
using LivroMente.API.Requests;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Service.Interfaces;
using Moq;
using Xunit;

namespace LivroMente.Tests.Handler.CategoryBookHandlerTest
{
    public class UpdateCategoryBookHandlerTest
    {
        private readonly Mock<ICategoryBookService> _service;
        private readonly UpdateCategoryBookHandler _handler;

        public UpdateCategoryBookHandlerTest()
        {
            _service = new Mock<ICategoryBookService>();
            _handler = new UpdateCategoryBookHandler(_service.Object);
        }

        [Fact]
        public async void Handler_ReturnFalse_WhenCategoryIsNotUpdate()
        {
            var id = Guid.NewGuid().ToString();
            var request = new CategoryBookUpdateCommand(id, new CategoryBookRequest { Description = "Teste", IsActive = true });
            var category = new CategoryBook("Teste", true);

            _service.Setup(x => x.GetById(request.Id)).ReturnsAsync(category);
            _service.Setup(x => x.Update(category.Id)).ReturnsAsync(false);

            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.False(result);
        }

        [Fact]
        public async void Handler_ReturnTrue_WhenCategoryIsUpdate()
        {
            var id = Guid.NewGuid().ToString();
            var request = new CategoryBookUpdateCommand(id, new CategoryBookRequest { Description = "Teste", IsActive = true });
            var category = new CategoryBook("Teste", true);

            _service.Setup(x => x.GetById(request.Id)).ReturnsAsync(category);
            _service.Setup(x => x.Update(category.Id)).ReturnsAsync(true);

            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
    }
}
