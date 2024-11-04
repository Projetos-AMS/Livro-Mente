using FluentValidation;
using LivroMente.API.Commands.CategoryBookCommands;

namespace LivroMente.API.Validators.CategoryBook
{
    public class CategoryBookUpdateCommandValidator : AbstractValidator<CategoryBookUpdateCommand>
    {
        public CategoryBookUpdateCommandValidator()
        {
            RuleFor(_ => _.CategoryBookRequest.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .MinimumLength(3)
                .WithMessage("Description must be longer than 3 characters")
                .MaximumLength(80)
                .WithMessage("Description must be short than 80 characters");
        }
    }
}