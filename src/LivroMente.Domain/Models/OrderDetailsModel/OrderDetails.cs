using LivroMente.Domain.Models.BookModel;
using LivroMente.Domain.Models.OrderModel;

namespace LivroMente.Domain.Models.OrderDetailsModel
{
    public class OrderDetails
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
        public int Amount { get; set; }
        public float ValueUni { get; set; }

    }
}