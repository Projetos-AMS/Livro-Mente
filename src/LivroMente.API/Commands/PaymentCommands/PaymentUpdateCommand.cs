using LivroMente.API.Requests;
using MediatR;

namespace LivroMente.API.Commands.PaymentCommands
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