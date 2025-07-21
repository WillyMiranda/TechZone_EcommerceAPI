using FluentValidation;

namespace TechZone.Ecommerce.UseCases.SubCategories.Commands.DeleteSubCategoryCommand
{
    public sealed class DeleteSubCategoryValidator:AbstractValidator<DeleteSubCategoryCommand>
    {
        public DeleteSubCategoryValidator()
        {
            RuleFor(command => command.Id)
                .NotNull().NotEmpty().WithMessage("El ID de la sub-categoría es requerido.")
                .Must(id => id != Guid.Empty).WithMessage("El ID de la sub-categoría no puede ser un GUID vacío.");
        }
    }
}
