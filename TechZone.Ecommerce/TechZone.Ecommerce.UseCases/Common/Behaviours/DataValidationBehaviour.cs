using FluentValidation;
using MediatR;
using TechZone.Ecommerce.Transversal;
using TechZone.Ecommerce.UseCases.Common.Exceptions;

namespace TechZone.Ecommerce.UseCases.Common.Behaviours
{
    internal sealed class DataValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public DataValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.Where(r => r.Errors.Any()).SelectMany(r => r.Errors)
                    .Select(r => new BaseError() { PropertyMessage = r.PropertyName, ErrorMessage = r.ErrorMessage })
                    .ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationExceptionCustom(failures);
                }
            }

            return await next(cancellationToken);
        }
    }
}
