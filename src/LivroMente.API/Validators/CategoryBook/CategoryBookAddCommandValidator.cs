using FluentValidation;
using LivroMente.API.Requests;

namespace LivroMente.Domain.Validators
{
    public class CategoryBookAddCommandValidator : AbstractValidator<CategoryBookAddCommand>
    {
        public CategoryBookAddCommandValidator()
        {
            RuleFor(_ => _.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MinimumLength(3)
            .WithMessage("Description must be longer than 3 characters")
            .MaximumLength(80)
            .WithMessage("Description must be short than 80 characters");
        }
    }
}