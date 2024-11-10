namespace LivroMente.Service.Dtos
{
    public class OrderDto
    {
         public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public float ValueTotal { get; set; }
        public UserDto User { get; set; }
        public ICollection<OrderDetailsDto> OrderDetails { get; set; }
    }
}