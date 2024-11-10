using MediatR;

namespace LivroMente.API.Commands.CategoryBookCommands
{
    public class CategoryBookDeleteCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public CategoryBookDeleteCommand(string id)
        {
            Id = id;
        }
    }
}