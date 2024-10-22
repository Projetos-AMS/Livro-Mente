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