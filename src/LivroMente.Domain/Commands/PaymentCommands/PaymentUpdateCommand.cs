using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Requests;
using MediatR;

namespace LivroMente.Domain.Commands.PaymentCommands
{
    public class PaymentUpdateCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public PaymentRequest PaymentRequest { get; set; }
        public PaymentUpdateCommand(Guid id,PaymentRequest paymentRequest)
        {
            Id = id;
            PaymentRequest = paymentRequest;
        }
    }
}