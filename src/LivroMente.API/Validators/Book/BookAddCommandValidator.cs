//using FluentValidation;
//using LivroMente.API.Commands.BookCommands;

//namespace LivroMente.API.Validators.Book
//{
//    public class BookAddCommandValidator : AbstractValidator<BookAddCommand>
//    {
//        public BookAddCommandValidator()
//        {
//            RuleFor(_ => _.BookRequest.Title)
//                .NotEmpty()
//                .WithMessage("Title is required.")
//                .MinimumLength(2)
//                .WithMessage("Title must be longer than 2 characters")
//                .MaximumLength(50)
//                .WithMessage("Title must be short than 50 characters");
            
//            RuleFor(_ => _.BookRequest.Author)
//                .NotEmpty()
//                .WithMessage("Author is required.")
//                .MinimumLength(2)
//                .WithMessage("Author must be longer than 2 characters")
//                .MaximumLength(60)
//                .WithMessage("Author must be short than 60 characters");

//            RuleFor(_ => _.BookRequest.Synopsis)
//                .MaximumLength(300)
//                .WithMessage("Synopsis must be short than 300 characters");
            
//            RuleFor(_ => _.BookRequest.PublishingCompany)
//                .NotEmpty()
//                .WithMessage("PublishingCompany is required.")
//                .MinimumLength(2)
//                .WithMessage("PublishingCompany must be longer than 2 characters")
//                .MaximumLength(20)
//                .WithMessage("PublishingCompany must be short than 20 characters");

//            RuleFor(_ => _.BookRequest.Isbn)
//                .MaximumLength(20)
//                .WithMessage("Isbn must be short than 20 characters");
        

//            RuleFor(_ => _.BookRequest.Language)
//                .NotEmpty()
//                .WithMessage("Language is required.")
//                .MaximumLength(2)
//                .WithMessage("Language must be short than 2 characters");

//            RuleFor(_ => _.BookRequest.Classification)
//                .NotEmpty()
//                .WithMessage("Classification is required.");

//            RuleFor(_ => _.BookRequest.CategoryId)
//                .NotEmpty()
//                .WithMessage("Category is required.");
//        }
//    }
//}