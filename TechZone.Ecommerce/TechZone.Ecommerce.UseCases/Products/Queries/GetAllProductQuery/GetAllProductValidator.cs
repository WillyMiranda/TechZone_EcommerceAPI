using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Products.Queries.GetAllProductQuery
{
    public sealed class GetAllProductValidator: AbstractValidator<GetAllProductQuery>
    {
        public GetAllProductValidator()
        {
            RuleFor(x => x.ProductName).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.ProductName)).WithMessage("El nombre del producto no puede exceder los 50 caracteres.");
            RuleFor(x => x.CategoryId).NotEmpty().When(x => x.CategoryId.HasValue).WithMessage("El ID de la categoría no puede estar vacío.");
            RuleFor(x => x.SubCategoryId).NotEmpty().When(x => x.SubCategoryId.HasValue).WithMessage("El ID de la subcategoría no puede estar vacío.");
            RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("El número de página debe ser mayor que 0.");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("El tamaño de la página debe ser mayor que 0.");
        }
    }
}
