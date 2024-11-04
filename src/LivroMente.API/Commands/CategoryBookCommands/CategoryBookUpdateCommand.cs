using LivroMente.API.Requests;
using MediatR;

namespace LivroMente.API.Commands.CategoryBookCommands
{
    public class CategoryBookUpdateCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public CategoryBookRequest CategoryBookRequest { get; set; }
        public CategoryBookUpdateCommand(Guid id, CategoryBookRequest categoryBookRequest)
        {
            Id = id;
            CategoryBookRequest = categoryBookRequest;
        }
    }
}