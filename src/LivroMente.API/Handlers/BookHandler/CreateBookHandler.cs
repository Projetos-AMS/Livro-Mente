using AutoMapper;
using LivroMente.Domain.Commands.BookCommands;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.BookHandler
{
    public class CreateBookHandler : IRequestHandler<BookAddCommand, bool>
    {
        private readonly BookService _bookService;
        private readonly IMapper _mapper;

        public CreateBookHandler(BookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(BookAddCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Synopsis = request.Synopsis,
                Quantity = request.Quantity,
                Pages = request.Pages,
                PublishingCompany = request.PublishingCompany,
                Isbn = request.Isbn,
                Value = request.Value,
                Language = request.Language,
                Classification = request.Classification,
                IsActive = request.IsActive,
                CategoryId = request.CategoryId,
                UrlBook = request.UrlBook,
                UrlImg = request.UrlImg,
            };

            var result = await _bookService.Add(book);
            if(!result) return false;
            return true;
}
    }

}