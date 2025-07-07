using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Commands.CreateUserCommand
{
    public sealed class CreateUserCommand: IRequest<Response<bool>>
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public bool LockoutEnabled { get; init; }
        public bool TwoFactorEnabled { get; init; }
        public string Password { get; init; }
        public string RoleName { get; init; }
    }
}
