using LivroMente.API.ViewModels;
using MediatR;

namespace LivroMente.API.Commands.AdminCommands
{
    public class AdminAllOrdersCommand : IRequest<List<AllOrders>>
    {
        
    }
}