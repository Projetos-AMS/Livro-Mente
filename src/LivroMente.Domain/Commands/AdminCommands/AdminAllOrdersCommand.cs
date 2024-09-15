using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.ViewModels;
using MediatR;

namespace LivroMente.Domain.Commands.AdminCommands
{
    public class AdminAllOrdersCommand : IRequest<List<AllOrders>>
    {
        
    }
}