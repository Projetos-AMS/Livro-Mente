using LivroMente.Data.Context;
using LivroMente.Domain.Models;
using LivroMente.Service.Interfaces;
using LivroMente.Service.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace LivroMente.Tests.Services
{
    public class BaseServiceTest
    {
        private readonly Mock<DataContext> _context;
        private readonly BaseService<Entity> _service;

        public BaseServiceTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                          .UseInMemoryDatabase(databaseName: "TestDatabase")
                          .Options;
            _context = new Mock<DataContext>(options);
            _service = new BaseService<Entity>(_context.Object);
        }

        [Fact]
        public async Task Service_ReturnTrue_WhenAddEntity()
        {
            var entity = new Mock<Entity>().Object;

            var result = await _service.Add(entity);

            _context.Verify(context => context.Add(entity), Times.Once);
            _context.Verify(context => context.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task Service_ReturnTrue_WhenDeleteEntity()
        {
            var id = "123"; 
            var entity = new Mock<Entity>();
        

            _context.Setup(x => x.Set<Entity>().FindAsync(id)).ReturnsAsync(entity.Object);

            _context.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var result = await _service.Delete(id);

            _context.Verify(context => context.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async void Service_ReturnTrue_WhenUpdateEntity()
        {
            var id = "123";
            var entity = new Mock<Entity>();


            _context.Setup(x => x.Set<Entity>().FindAsync(id)).ReturnsAsync(entity.Object);

            _context.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var result = await _service.Update(id);

            _context.Verify(context => context.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.True(result);
        }
    }

    
}
