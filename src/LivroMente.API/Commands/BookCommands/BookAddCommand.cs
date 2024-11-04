using LivroMente.API.Requests;
using MediatR;

namespace LivroMente.API.Commands.BookCommands
{
    public class BookAddCommand : IRequest<bool>
    {
        public BookRequest BookRequest { get; set; }
    }
}