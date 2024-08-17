using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.CategoryBookCommands;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.CategoryBookHandler
{
    public class DeleteCategoryBookHandler : IRequestHandler<CategoryBookDeleteCommand, bool>
    {
        private readonly CategoryBookService _categoryBookService;

        public DeleteCategoryBookHandler(CategoryBookService categoryBookService)
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