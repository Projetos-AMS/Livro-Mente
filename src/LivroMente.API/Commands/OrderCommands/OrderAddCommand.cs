using LivroMente.API.Requests;
using MediatR;

namespace LivroMente.Domain.Commands.OrderCommands
{
    public class OrderAddCommand : IRequest<bool>
    {
       public OrderRequest OrderRequest { get; set; }
    }
}