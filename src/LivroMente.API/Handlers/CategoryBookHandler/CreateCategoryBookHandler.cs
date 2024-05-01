using AutoMapper;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Domain.Requests;
using LivroMente.Domain.ViewModels;
using LivroMente.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LivroMente.API.Handlers.CategoryBookHandler
{
    public class CreateCategoryBookHandler : IRequestHandler<CategoryBookAddCommand, bool>
    {
        private readonly CategoryBookService _categoryBookService;

        public CreateCategoryBookHandler(CategoryBookService categoryBookService)
        {
            _categoryBookService = categoryBookService;
        }
        public async Task<bool> Handle(CategoryBookAddCommand request, CancellationToken cancellationToken)
        {
            var category = new CategoryBook
            {
                Description = request.Description,
                IsActive = request.IsActive
            };

            var result = await _categoryBookService.Add(category);
            if(!result) return false;
            return true;
        }
    }
}