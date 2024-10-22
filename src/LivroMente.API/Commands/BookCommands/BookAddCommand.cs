using LivroMente.Domain.Requests;
using MediatR;

namespace LivroMente.Domain.Commands.BookCommands
{
    public class BookAddCommand : IRequest<bool>
    {
        public BookRequest BookRequest { get; set; }
    }
}