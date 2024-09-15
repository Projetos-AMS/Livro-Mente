using LivroMente.Domain.Models.OrderDetailsModel;
using MediatR;

namespace LivroMente.Domain.Commands.OrderCommands
{
    public class OrderAddCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public float ValueTotal { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}