using FluentValidation;

namespace TechZone.Ecommerce.UseCases.SubCategories.Queries.GetByIdSubCategoryQuery
{
    public sealed class GetByIdSubCategoryValidator : AbstractValidator<GetByIdSubCategoryQuery>
    {
        public GetByIdSubCategoryValidator()
        {
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("El ID de la sub-categoría es requerido.")
                .Must(id => id != Guid.Empty).WithMessage("El ID de la sub-categoría no puede ser un GUID vacío.");
        }
    }
}
