using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Products.Queries.GetByIdProductQuery
{
    public sealed class GetByIdProductValidator : AbstractValidator<GetByIdProductQuery>
    {
        public GetByIdProductValidator()
        {
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("El ID del producto es requerido.")
                .Must(id => id != Guid.Empty).WithMessage("El ID del producto no puede ser un GUID vacío.");
        }
    }
}
