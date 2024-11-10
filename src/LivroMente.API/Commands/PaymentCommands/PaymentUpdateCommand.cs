using LivroMente.API.Requests;
using MediatR;

namespace LivroMente.API.Commands.PaymentCommands
{
    public class PaymentUpdateCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public PaymentRequest PaymentRequest { get; set; }
        public PaymentUpdateCommand(string id,PaymentRequest paymentRequest)
        {
            Id = id;
            PaymentRequest = paymentRequest;
        }
    }
}