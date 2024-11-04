using FluentValidation;
using LivroMente.API.Commands.UserCommands;

namespace LivroMente.API.Validators.User
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(_ => _.CompleteName)
                .NotEmpty()
                .WithMessage("CompleteName is required.")
                .MaximumLength(100)
                .WithMessage("CompleteName must be short than 100 characters");

            RuleFor(_ => _.Email)
                .NotEmpty()
                .WithMessage("Email is required.");

            RuleFor(_ => _.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be longer than 6 characters");

            RuleFor(_ => _.ConfirmPassword)
                .NotEmpty()
                .WithMessage("ConfirmPassword is required.");

            RuleFor(_ => _.Role)
                .NotEmpty()
                .WithMessage("Role is required.");
        }
    }
}