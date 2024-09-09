namespace LivroMente.Domain.Requests
{
    public class BookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Synopsis { get; set; }
        public int Quantity { get; set; }
        public int Pages { get; set; }
        public string PublishingCompany { get; set; }
        public string Isbn { get; set; }
        public double Value { get; set; }
        public string Language { get; set; }
        public int Classification { get; set; }
        public bool IsActive { get; set; }
        public Guid CategoryId { get; set; }
        public string UrlBook { get; set; }
        public string UrlImg { get; set; }
    }
}