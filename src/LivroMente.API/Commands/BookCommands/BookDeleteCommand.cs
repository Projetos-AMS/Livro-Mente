using MediatR;

namespace LivroMente.API.Commands.BookCommands
{
    public class BookDeleteCommand : IRequest<bool>
    {
          public Guid Id { get; set; }
        public BookDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}