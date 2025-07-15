using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Commands.LastAccessUserCommand
{
    public sealed class LastAccessUserCommand: IRequest<Response<bool>>
    {
        public DateTime LastAccess { get; init; }
    }
}
