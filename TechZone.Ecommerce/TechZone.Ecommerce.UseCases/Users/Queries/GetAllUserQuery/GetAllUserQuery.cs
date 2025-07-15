using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Queries.GetAllUserQuery
{
    public sealed record GetAllUserQuery: IRequest<Response<IEnumerable<UserDto>>>
    {
    }
}
