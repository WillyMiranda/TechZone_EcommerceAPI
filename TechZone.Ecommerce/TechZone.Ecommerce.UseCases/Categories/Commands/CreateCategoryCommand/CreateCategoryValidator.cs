using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Categories.Commands.CreateCategoryCommand
{
    public sealed class CreateCategoryValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(command => command.Name)
                .NotNull().NotEmpty().WithMessage("El nombre es requerido")
                .MaximumLength(50).WithMessage("El nombre no debe exceder 50 caracteres.");

            RuleFor(command => command.Image)
                .NotNull().NotEmpty().WithMessage("El URL de la imagen es requerido.")
                .MaximumLength(255).WithMessage("El URL de la imagen no debe exceder 255 caracteres.");
        }
    }
}
