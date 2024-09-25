using LivroMente.Domain.Models.OrderDetailsModel;

namespace LivroMente.Domain.Models.OrderModel
{
    public class Order : Entity
    {
        public Order()
        {
            
        }
        public Order(string userId, Guid paymentId,DateTime date, float valueTota,ICollection<OrderDetails> orderDetailsl)
        {
            UserId = userId;
            PaymentId = paymentId;
            Date = date;
            ValueTotal = valueTota;
            OrderDetails = orderDetailsl;

        }
        public string UserId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public float ValueTotal { get; set; }
        public string  Status { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}