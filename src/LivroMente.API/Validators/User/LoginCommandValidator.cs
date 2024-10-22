using FluentValidation;
using LivroMente.Domain.Commands.UserCommands;

namespace LivroMente.API.Validators.User
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(_ => _.Email)
                .NotEmpty()
                .WithMessage("Email is required.");
        }
    }
}