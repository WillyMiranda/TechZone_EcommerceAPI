using FluentValidation;

namespace TechZone.Ecommerce.UseCases.SubCategories.Queries.GetAllByCategorySubCategoryQuery
{
    public sealed class GetAllByCategorySubCategoryValidator: AbstractValidator<GetAllByCategorySubCategoryQuery>
    {
        public GetAllByCategorySubCategoryValidator()
        {
            RuleFor(command => command.CategoryId)
                .NotNull().NotEmpty().WithMessage("El ID de la categoría es requerido.")
                .Must(id => id != Guid.Empty).WithMessage("El ID de la categoría no puede ser un GUID vacío.");
        }
    }
}
