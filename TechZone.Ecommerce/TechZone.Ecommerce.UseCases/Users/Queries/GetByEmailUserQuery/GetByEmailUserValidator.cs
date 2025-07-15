using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Users.Queries.GetByEmailUserQuery
{
    public sealed class GetByEmailUserValidator: AbstractValidator<GetByEmailUserQuery>
    {
        public GetByEmailUserValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("El correo del usuario no puede ser nulo.")
                .NotEmpty().WithMessage("El correo del usuario no puede estar vacío.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.");
        }
    }
}
