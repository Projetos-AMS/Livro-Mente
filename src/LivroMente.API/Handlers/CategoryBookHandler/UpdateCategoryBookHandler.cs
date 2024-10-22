using LivroMente.Domain.Commands.CategoryBookCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.CategoryBookHandler
{
    public class UpdateCategoryBookHandler : IRequestHandler<CategoryBookUpdateCommand, bool>
    {
        private readonly ICategoryBookService _categoryBookService;

        public UpdateCategoryBookHandler(ICategoryBookService categoryBookService)
        {
            _categoryBookService = categoryBookService;
        }
        public async Task<bool> Handle(CategoryBookUpdateCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryBookService.GetById(request.Id);
            if(category == null)return false;
            category.Description = request.CategoryBookRequest.Description;
            category.IsActive = request.CategoryBookRequest.IsActive;

            var result = await _categoryBookService.Update(category.Id);
            if(!result) return false;
            return true;
        }
    }
}