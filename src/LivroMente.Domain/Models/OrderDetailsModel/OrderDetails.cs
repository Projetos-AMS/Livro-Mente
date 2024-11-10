using LivroMente.Domain.Models.BookModel;

namespace LivroMente.Domain.Models.OrderDetailsModel
{
    public class OrderDetails : Entity
    {
        public OrderDetails()
        {
        }
        public OrderDetails(string orderId,string bookId,int amount,float valueUni)
        {
            OrderId = orderId;
            BookId = bookId;
            Amount = amount;
            ValueUni = valueUni;
        }
        public string OrderId { get; set; }
        public string BookId { get; set; }
        public int Amount { get; set; }
        public float ValueUni { get; set; }
        public Book Book{ get; set; }

    }
}