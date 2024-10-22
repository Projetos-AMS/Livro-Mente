using LivroMente.Domain.Requests;
using MediatR;

namespace LivroMente.Domain.Commands.BookCommands
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