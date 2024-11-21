using LivroMente.Domain.Models.OrderDetailsModel;

namespace LivroMente.API.Requests
{
    public class OrderRequest
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; } 
        public float ValueTotal { get; set; }
        public string Status { get; set; }
        public ICollection<OrderDetailsRequest> OrderDetails { get; set; }
    }
}