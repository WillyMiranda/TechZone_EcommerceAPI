using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Categories.Queries.GetByIdCategoryQuery
{
    public sealed class GetByIdCategoryValidator : AbstractValidator<GetByIdCategoryQuery>
    {
        public GetByIdCategoryValidator()
        {
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("El ID de la categoría es requerido.")
                .Must(id => id != Guid.Empty).WithMessage("El ID de la categoría no puede ser un GUID vacío.");
        }
    }
}
