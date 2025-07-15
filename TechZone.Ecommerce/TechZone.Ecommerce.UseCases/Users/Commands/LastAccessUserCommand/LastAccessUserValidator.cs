using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Users.Commands.LastAccessUserCommand
{
    public sealed class LastAccessUserValidator: AbstractValidator<LastAccessUserCommand>
    {
        public LastAccessUserValidator()
        {
            RuleFor(x => x.LastAccess)
                .NotNull().NotEmpty().WithMessage("La fecha de último acceso no puede ser nula o vacía.");
        }
    }
}
