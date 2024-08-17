using LivroMente.Domain.Commands.BookCommands;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.BookHandler
{
    public class DeleteBookHandler : IRequestHandler<BookDeleteCommand, bool>
    {
        private readonly BookService _bookService;
        public DeleteBookHandler(BookService bookService)
        {
            _bookService = bookService;
            
        }
        public async Task<bool> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetById(request.Id);
            if(book == null) return false;
            var result = await _bookService.Delete(book.Id);
            if(!result) return false;
            return true;
        }
    }
}