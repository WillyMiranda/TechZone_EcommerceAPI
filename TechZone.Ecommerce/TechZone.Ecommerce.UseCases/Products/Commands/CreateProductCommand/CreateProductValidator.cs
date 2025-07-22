using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Products.Commands.CreateProductCommand
{
    internal sealed class CreateProductValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Sku)
                .NotNull().NotEmpty().WithMessage("El SKU es requerido.")
                .MaximumLength(30).WithMessage("El SKU no puede exceder los 30 caracteres.");

            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.Price)
                .NotNull().NotEmpty().WithMessage("El precio es requerido.")
                .GreaterThan(0).WithMessage("El precio debe ser mayor que cero.");

            RuleFor(x => x.Cost)
                .NotNull().NotEmpty().WithMessage("El costo es requerido.")
                .GreaterThan(0).WithMessage("El costo debe ser mayor que cero.");

            RuleFor(x => x.Image)
                .NotNull().NotEmpty().WithMessage("La URL de la imagen es requerida.")
                .MaximumLength(300).WithMessage("La URL de la imagen no puede exceder los 300 caracteres.");

            RuleFor(x => x.Stock)
                .NotNull().NotEmpty().WithMessage("El stock es requerido.")
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");

            RuleFor(x => x.MinimumStock)
                .NotNull().NotEmpty().WithMessage("El stock mínimo es requerido.")
                .GreaterThanOrEqualTo(0).WithMessage("El stock mínimo no puede ser negativo.");

            RuleFor(x => x.Description)
                .NotNull().NotEmpty().WithMessage("La descripción es requerida.");

            RuleFor(x => x.Specifications)
                .NotNull().NotEmpty().WithMessage("Las especificaciones son requeridas.")
                .Must(specs => specs.Count > 0).WithMessage("Debe proporcionar al menos una especificación.");

            RuleFor(x => x.FreeShipping)
                .NotNull().WithMessage("El campo de envío gratuito es requerido.");

            RuleFor(x => x.Featured)
                .NotNull().WithMessage("El campo destacado es requerido.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("La categoría es requerida.")
                .NotEqual(Guid.Empty).WithMessage("La categoría no puede ser un GUID vacío.");

            RuleFor(x => x.SubCategoryId)
                    .NotEqual(Guid.Empty).When(x => x.SubCategoryId.HasValue).WithMessage("La subcategoría no puede ser un GUID vacío.");
        }
    }
}
