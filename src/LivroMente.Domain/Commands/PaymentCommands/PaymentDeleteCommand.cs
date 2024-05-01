using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace LivroMente.Domain.Commands.PaymentCommands
{
    public class PaymentDeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public PaymentDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}