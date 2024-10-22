using LivroMente.Data.Context;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Service.Interfaces;

namespace LivroMente.Service.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        public BookService(DataContext context) : base(context){}
    }
}