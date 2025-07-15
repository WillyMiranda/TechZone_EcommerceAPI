using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Commands.UpdateUserCommand
{
    public sealed record UpdateUserCommand: IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public bool LockoutEnabled { get; init; }
        public bool TwoFactorEnabled { get; init; }
        public Guid RoleId { get; init; }
        public string RoleName { get; init; }
    }
}
