using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace LivroMente.API.Commands.OrderCommands
{
    public class OrderDisableCommand : IRequest<bool>
    {
        public OrderDisableCommand(string id)
        {
            Id=id;
        }
        public string Id { get; private set; }
    }
}