using FluentValidation;
using LivroMente.Domain.Exceptions;
using MediatR;


namespace LivroMente.Domain.Validators;

public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private const string Message = "Validation error";
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (failures.Any())
        {
            var errorMessages = string.Join(", ", failures.Select(f => f.ErrorMessage));

            throw new LivroMenteException(
                $"Command Validation Errors for type {typeof(TRequest).Name}: {errorMessages}",
                new ValidationException(errorMessages, failures)
            );
            
        }

        return await next();
    }
}
