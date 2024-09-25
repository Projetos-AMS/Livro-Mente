using MediatR;

namespace LivroMente.Domain.Commands.PaymentCommands
{
    public class PaymentAddCommand : IRequest<bool>
    {
        public string Description { get; set; }
    }
}