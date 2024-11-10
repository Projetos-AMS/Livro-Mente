using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Domain.Models.OrderDetailsModel;

namespace LivroMente.Domain.Models.OrderModel
{
    public class Order : Entity
    {
        public Order()
        {
            
        }
        public Order(string userId, string paymentId,DateTime date, float valueTota,string status,ICollection<OrderDetails> orderDetailsl)
        {
            UserId = userId;
            PaymentId = paymentId;
            Date = date;
            ValueTotal = valueTota;
            Status = status;
            OrderDetails = orderDetailsl;

        }
        public string UserId { get; set; }
        public string PaymentId { get; set; }
        public DateTime Date { get; set; } 
        public float ValueTotal { get; set; }
        public string  Status { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

        public void Disabled()
        {
            Status = "Cancelado";
        }
    }

    
}