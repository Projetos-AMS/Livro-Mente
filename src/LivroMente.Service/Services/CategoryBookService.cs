using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Data.Context;
using LivroMente.Domain.Models.CategoryBookModel;

namespace LivroMente.Service.Services
{
    public class CategoryBookService : BaseService<CategoryBook>
    {
        public CategoryBookService(DataContext context) : base(context)
        {
        }
    }
}