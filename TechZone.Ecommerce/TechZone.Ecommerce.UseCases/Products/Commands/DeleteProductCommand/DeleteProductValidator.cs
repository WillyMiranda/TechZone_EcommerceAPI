using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Products.Commands.DeleteProductCommand
{
    public sealed class DeleteProductValidator:AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(command => command.Id)
                .NotNull().NotEmpty().WithMessage("El ID del producto es requerido.")
                .Must(id => id != Guid.Empty).WithMessage("El ID del producto no puede ser un GUID vacío.");
        }
    }
}
