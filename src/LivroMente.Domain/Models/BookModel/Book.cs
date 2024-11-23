
using LivroMente.Domain.Models.CategoryBookModel;

namespace LivroMente.Domain.Models.BookModel
{
    public class Book : Entity
    {
        public Book()
        {
        }

        public Book(string title,string author,string synopsis,int quantity,int pages,
            string publishingCompany,string isbn,double value,string language,int classification,
            bool isActive,string categoryId,string urlBook,string urlImg)
        {
            Title = title;
            Author = author;
            Synopsis = synopsis;
            Quantity = quantity;
            Pages = pages;
            PublishingCompany = publishingCompany;
            Isbn = isbn;
            Value = value;
            Language = language;
            Classification = classification;
            IsActive = isActive;
            CategoryId = categoryId;
            UrlBook = urlBook;
            UrlImg = urlImg;
        }

        

        public string  Title { get; set; }
        public string Author { get; set; }
        public string Synopsis { get; set; } 
        public int Quantity { get; set; }
        public int Pages { get; set; }
        public string PublishingCompany { get; set; }
        public string Isbn { get; set; }
        public double  Value { get; set; }
        public string Language { get; set; }
        public int Classification { get; set; }
        public bool IsActive { get; set; }
        public string CategoryId { get; set; }
        public string UrlBook { get; set; }
        public string UrlImg { get; set; }
        public CategoryBook CategoryBook { get; set; }

        public void Disabled()
        {
            IsActive = false;
        }
       
    }
}