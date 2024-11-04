using MediatR;

namespace LivroMente.API.Requests
{
    public class CategoryBookAddCommand : IRequest<bool>
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}