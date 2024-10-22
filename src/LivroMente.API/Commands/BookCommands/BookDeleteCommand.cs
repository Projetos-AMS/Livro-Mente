using MediatR;

namespace LivroMente.Domain.Commands.BookCommands
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