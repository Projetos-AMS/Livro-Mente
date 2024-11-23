using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.API.Commands.BookCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.BookHandler
{
    public class DisableBookHandler : IRequestHandler<BookDisableCommand, bool?>
    {
        private readonly IBookService _service;

        public DisableBookHandler(IBookService service)
        {
            _service = service;
        }
        public async Task<bool?> Handle(BookDisableCommand request, CancellationToken cancellationToken)
        {
           var book = await _service.GetById(request.Id);
            if(book == null) return false;

            book.Disabled();
            await _service.Save();
            return true;
        }
    }
}