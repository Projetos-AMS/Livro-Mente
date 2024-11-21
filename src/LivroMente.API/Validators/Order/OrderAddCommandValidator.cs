using FluentValidation;
using LivroMente.API.Commands.OrderCommands;

namespace LivroMente.API.Validators.Order
{
    public class OrderAddCommandValidator : AbstractValidator<OrderAddCommand>
    {
        public OrderAddCommandValidator()
        {
            RuleFor(_ => _.OrderRequest.Date)
                .NotEmpty()
                .WithMessage("Date is required.");
            
            RuleFor(_ => _.OrderRequest.ValueTotal)
                .NotEmpty()
                .WithMessage("ValueTotal is required.");

            RuleFor(_ => _.OrderRequest.UserId)
                .NotEmpty()
                .WithMessage("User is required.");
        }
    }
}