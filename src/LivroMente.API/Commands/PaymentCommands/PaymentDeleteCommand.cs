using MediatR;

namespace LivroMente.API.Commands.PaymentCommands
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