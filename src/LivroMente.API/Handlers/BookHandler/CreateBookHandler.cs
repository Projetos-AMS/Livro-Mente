using LivroMente.Domain.Commands.BookCommands;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.BookHandler
{
    public class CreateBookHandler : IRequestHandler<BookAddCommand, bool>
    {
        private readonly IBookService _bookService;

        public CreateBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<bool> Handle(BookAddCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            (
                request.BookRequest.Title,
                request.BookRequest.Author,
                request.BookRequest.Synopsis,
                request.BookRequest.Quantity,
                request.BookRequest.Pages,
                request.BookRequest.PublishingCompany,
                request.BookRequest.Isbn,
                request.BookRequest.Value,
                request.BookRequest.Language,
                request.BookRequest.Classification,
                request.BookRequest.IsActive,
                request.BookRequest.CategoryId,
                request.BookRequest.UrlBook,
                request.BookRequest.UrlImg
            );

            var result = await _bookService.Add(book);
            if(!result) return false;
            return true;
}
    }

}