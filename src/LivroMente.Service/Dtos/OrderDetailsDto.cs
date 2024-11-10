namespace LivroMente.Service.Dtos
{
    public class OrderDetailsDto
    {
        public string BookId { get; set; }
        public int Amount { get; set; }
        public float ValueUni { get; set; }
        public BookDto Book { get; set; }
    }
}