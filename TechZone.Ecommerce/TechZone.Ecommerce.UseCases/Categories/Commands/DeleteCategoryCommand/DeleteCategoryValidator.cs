using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Categories.Commands.DeleteCategoryCommand
{
    public sealed class DeleteCategoryValidator:AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(command => command.Id)
                .NotNull().NotEmpty().WithMessage("El ID de la categoría es requerido.")
                .Must(id => id != Guid.Empty).WithMessage("El ID de la categoría no puede ser un GUID vacío.");
        }
    }
}
