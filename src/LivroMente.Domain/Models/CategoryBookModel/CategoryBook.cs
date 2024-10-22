namespace LivroMente.Domain.Models.CategoryBookModel
{
    public class CategoryBook : Entity
    {
        public CategoryBook()
        {
        }
        public CategoryBook(string description,bool isActive)
        {
            Description = description;
            IsActive = isActive;
        }
        
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}