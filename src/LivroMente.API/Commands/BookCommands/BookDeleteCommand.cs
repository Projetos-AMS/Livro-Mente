using MediatR;

namespace LivroMente.API.Commands.BookCommands
{
    public class BookDeleteCommand : IRequest<bool?>
    {
          public string Id { get; set; }
        public BookDeleteCommand(string id)
        {
            Id = id;
        }
    }
}