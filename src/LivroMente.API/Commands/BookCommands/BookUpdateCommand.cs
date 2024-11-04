using LivroMente.API.Requests;
using MediatR;

namespace LivroMente.API.Commands.BookCommands
{
    public class BookUpdateCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public BookRequest BookRequest { get; set; }

        public BookUpdateCommand(Guid id,BookRequest bookRequest)
        {
            Id = id;
            BookRequest = bookRequest;
        }
    }
}