using LivroMente.API.Commands.BookCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.BookHandler
{
    public class DeleteBookHandler : IRequestHandler<BookDeleteCommand, bool?>
    {
        private readonly IBookService _bookService;
        public DeleteBookHandler(IBookService bookService)
        {
            _bookService = bookService;
            
        }
        public async Task<bool?> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetById(request.Id);
            if(book == null) return null;
            var result = await _bookService.Delete(book.Id);
            if(!result) return false;
            return true;
        }
    }
}