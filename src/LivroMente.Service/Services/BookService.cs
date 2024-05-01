using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Data.Context;
using LivroMente.Domain.Models.BookModel;

namespace LivroMente.Service.Services
{
    public class BookService : BaseService<Book>
    {
        public BookService(DataContext context) : base(context)
        {
        }
    }
}