using LivroMente.Domain.Models.OrderDetailsModel;

namespace LivroMente.API.Requests
{
    public class OrderRequest
    {
        public string UserId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime Date { get; set; } 
        public float ValueTotal { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}