using MediatR;

namespace LivroMente.API.Commands.PaymentCommands
{
    public class PaymentDeleteCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public PaymentDeleteCommand(string id)
        {
            Id = id;
        }
    }
}