using LivroMente.API.Requests;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.CategoryBookHandler
{
    public class CreateCategoryBookHandler : IRequestHandler<CategoryBookAddCommand, bool>
    {
        private readonly ICategoryBookService _categoryBookService;
        

        public CreateCategoryBookHandler(ICategoryBookService categoryBookService)
        {
            _categoryBookService = categoryBookService;
        }
        public async Task<bool> Handle(CategoryBookAddCommand request, CancellationToken cancellationToken)
        {
            var category = new CategoryBook
            (
                request.Description,
                request.IsActive
            );

            var result = await _categoryBookService.Add(category);
           
            if(!result) return false;
            return true;
        }
    }
}