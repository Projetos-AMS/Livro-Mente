using LivroMente.Domain.Models.BookModel;

namespace LivroMente.Domain.Models.OrderDetailsModel
{
    public class OrderDetails : Entity
    {
        public OrderDetails()
        {
        }
        public OrderDetails(Guid orderId,Guid bookId,int amount,float valueUni)
        {
            OrderId = orderId;
            BookId = bookId;
            Amount = amount;
            ValueUni = valueUni;
        }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
        public int Amount { get; set; }
        public float ValueUni { get; set; }
        public Book Book{ get; set; }

    }
}