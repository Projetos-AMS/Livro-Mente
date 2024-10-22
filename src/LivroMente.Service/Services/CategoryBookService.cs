using LivroMente.Data.Context;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Service.Interfaces;

namespace LivroMente.Service.Services
{
    public class CategoryBookService : BaseService<CategoryBook>,ICategoryBookService
    {
        public CategoryBookService(DataContext context) : base(context){}
    }
}