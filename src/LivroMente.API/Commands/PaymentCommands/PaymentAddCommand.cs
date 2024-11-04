using MediatR;

namespace LivroMente.API.Commands.PaymentCommands
{
    public class PaymentAddCommand : IRequest<bool>
    {
        public string Description { get; set; }
    }
}