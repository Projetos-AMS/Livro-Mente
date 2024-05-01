using MediatR;

namespace LivroMente.Domain.Requests
{
    public class CategoryBookAddCommand : IRequest<bool>
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}