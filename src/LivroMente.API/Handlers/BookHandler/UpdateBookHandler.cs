using LivroMente.API.Commands.BookCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.BookHandler
{
    public class UpdateBookHandler : IRequestHandler<BookUpdateCommand, bool>
    {
        private readonly IBookService _bookService;

        public UpdateBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<bool> Handle(BookUpdateCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetById(request.Id);
            if(book == null) return false;
            book.Title = request.BookRequest.Title;
            book.Author = request.BookRequest.Author;
            book.Synopsis = request.BookRequest.Synopsis;
            book.Quantity = request.BookRequest.Quantity;
            book.Pages  = request.BookRequest.Pages;
            book.PublishingCompany = request.BookRequest.PublishingCompany;
            book.Isbn = request.BookRequest.Isbn;
            book.Value = request.BookRequest.Value;
            book.Language = request.BookRequest.Language;
            book.Classification = request.BookRequest.Classification;
            book.IsActive = request.BookRequest.IsActive;
            book.CategoryId = request.BookRequest.CategoryId;
            book.UrlBook = request.BookRequest.UrlBook;
            book.UrlImg = request.BookRequest.UrlImg;

            var result = await _bookService.Update(book.Id);
            if(!result) return false;
            return true;

        }
    }
}