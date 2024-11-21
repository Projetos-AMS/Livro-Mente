using LivroMente.API.Requests;
using MediatR;

namespace LivroMente.API.Commands.BookCommands
{
    public class BookUpdateCommand : IRequest<bool?>
    {
        public string Id { get; set; }
        public BookRequest BookRequest { get; set; }

        public BookUpdateCommand(string id,BookRequest bookRequest)
        {
            Id = id;
            BookRequest = bookRequest;
        }
    }
}