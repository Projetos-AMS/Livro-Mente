namespace LivroMente.Domain.Models.PaymentModel
{
    public class Payment : Entity
    {
        public Payment()
        {
        }
        public Payment(string description)
        {
            Description = description;
        }
        public string Description { get; set; }
    }
}