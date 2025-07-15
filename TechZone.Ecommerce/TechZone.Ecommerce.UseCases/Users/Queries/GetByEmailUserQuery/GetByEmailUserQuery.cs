using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Queries.GetByEmailUserQuery
{
    public sealed record GetByEmailUserQuery : IRequest<Response<UserDto>>
    {
        public string Email { get; init; }
    }
}
