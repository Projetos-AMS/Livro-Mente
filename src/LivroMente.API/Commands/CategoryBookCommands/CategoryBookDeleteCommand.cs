using MediatR;

namespace LivroMente.API.Commands.CategoryBookCommands
{
    public class CategoryBookDeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public CategoryBookDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}