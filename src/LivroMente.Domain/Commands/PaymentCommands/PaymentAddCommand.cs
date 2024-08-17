using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace LivroMente.Domain.Commands.PaymentCommands
{
    public class PaymentAddCommand : IRequest<bool>
    {
        public string Description { get; set; }
    }
}