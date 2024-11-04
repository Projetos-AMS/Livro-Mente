using LivroMente.API.Commands.CategoryBookCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.CategoryBookHandler
{
    public class DeleteCategoryBookHandler : IRequestHandler<CategoryBookDeleteCommand, bool>
    {
        private readonly ICategoryBookService _categoryBookService;

        public DeleteCategoryBookHandler(ICategoryBookService categoryBookService)
        {
            _categoryBookService = categoryBookService;
        }
        public async Task<bool> Handle(CategoryBookDeleteCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryBookService.GetById(request.Id);
            if(category == null) return false;
            var result = await _categoryBookService.Delete(category.Id);
            if(!result) return false;
            return true;
        }
    }
}