using LivroMente.API.Handlers.CategoryBookHandler;
using LivroMente.API.Requests;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Service.Interfaces;
using Moq;
using Xunit;

namespace LivroMente.Tests.Handler.CategoryBookHandlerTest
{
    public class CreateCategoryBokHandlerTest
    {
        private readonly Mock<ICategoryBookService> _service;
        private readonly CreateCategoryBookHandler _handler;

        public CreateCategoryBokHandlerTest()
        {
            _service = new Mock<ICategoryBookService>();
            _handler = new CreateCategoryBookHandler(_service.Object);
        }

        [Fact]
        public async void Handler_ReturnFalse_WhenCategoryNotCreate()
        {
            var request = new CategoryBookAddCommand
            {
                Description = "Test",
                IsActive = true,
            };

            _service.Setup(x => x.Add(It.IsAny<CategoryBook>())).ReturnsAsync(false);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.False(result);
        }

        [Fact]
        public async void Handler_ReturnTrue_WhenCategoryCreate()
        {
            var request = new CategoryBookAddCommand
            {
                Description = "Test",
                IsActive = true,
            };

            _service.Setup(x => x.Add(It.IsAny<CategoryBook>())).ReturnsAsync(true);
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
    }
}
