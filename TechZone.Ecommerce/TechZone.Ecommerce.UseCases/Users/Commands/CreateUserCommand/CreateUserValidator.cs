using FluentValidation;

namespace TechZone.Ecommerce.UseCases.Users.Commands.CreateUserCommand
{
    public sealed class CreateUserValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("El nombre del usuario es requerido.")
                .MaximumLength(50).WithMessage("El nombre del usuario no debe exceder los 50 caracteres.");

            RuleFor(x => x.PhoneNumber)
                .NotNull().NotEmpty().WithMessage("El teléfono no puede estar vacío.")
                .Length(8, 8).WithMessage("El teléfono debe contener 8 caracteres.");

            RuleFor(x => x.Email)
                .NotNull().NotEmpty().WithMessage("El correo no puede estar vacío.")
                .EmailAddress().WithMessage("El correo tiene un formato inválido.")
                .Length(1, 255).WithMessage("El correo debe contener entre 1 a 255 caracteres");

            RuleFor(x => x.LockoutEnabled).NotNull().WithMessage("La propiedad de Activar Bloqueo no puede ser nula.");

            RuleFor(x => x.TwoFactorEnabled).NotNull().WithMessage("El doble factor de verificación no puede ser nulo.");

            RuleFor(x => x.RoleName)
                .NotNull().NotEmpty().WithMessage("El rol es requerido.")
                .MaximumLength(6).WithMessage("El rol no debe exceder los 6 caracteres.");

            //la contraseña debe tener al menos 6 caracteres, una mayúscula, una minúscula, un número y un carácter especial
            RuleFor(x => x.Password)
                .NotNull().NotEmpty().WithMessage("La contraseña es requerida.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 8 caracteres.")
                .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
                .Matches("[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
                .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("La contraseña debe contener al menos un carácter especial.");

            //RuleFor(x => x.UserState)
            //    .NotNull().WithMessage("El estado del usuario no puede ser nulo.")
            //    .IsInEnum().WithMessage("El estado del usuario debe ser un valor válido.");
        }

    }
}
