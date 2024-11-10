using LivroMente.API.Requests;
using MediatR;

namespace LivroMente.API.Commands.CategoryBookCommands
{
    public class CategoryBookUpdateCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public CategoryBookRequest CategoryBookRequest { get; set; }
        public CategoryBookUpdateCommand(string id, CategoryBookRequest categoryBookRequest)
        {
            Id = id;
            CategoryBookRequest = categoryBookRequest;
        }
    }
}