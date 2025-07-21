using FluentValidation;

namespace TechZone.Ecommerce.UseCases.SubCategories.Commands.UpdateSubCategoryCommand
{
    public sealed class UpdateSubCategoryValidator:AbstractValidator<UpdateSubCategoryCommand>
    {
        public UpdateSubCategoryValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("El ID de la sub-categoría es requerido.")
                .Must(id => id != Guid.Empty).WithMessage("El ID de la sub-categoría no puede ser un GUID vacío.");

            RuleFor(command => command.Name)
                .NotNull().NotEmpty().WithMessage("El nombre es requerido")
                .MaximumLength(50).WithMessage("El nombre no debe exceder 50 caracteres.");

            RuleFor(command => command.Image)
                .NotNull().NotEmpty().WithMessage("El URL de la imagen es requerido.")
                .MaximumLength(255).WithMessage("El URL de la imagen no debe exceder 255 caracteres.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("El estado de la categoría es requerido.");

            RuleFor(command => command.CategoryId)
                .NotNull().NotEmpty().WithMessage("El ID de la categoría es requerido.")
                .Must(id => id != Guid.Empty).WithMessage("El ID de la categoría no puede ser un GUID vacío.");
        }
    }
}
