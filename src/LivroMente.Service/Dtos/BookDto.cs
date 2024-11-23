namespace LivroMente.Service.Dtos
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Value { get; set; }
        public string PublishingCompany { get; set; }
        public string UrlImg { get; set; }
        public CategoryDto Category { get; set; }
    }
}