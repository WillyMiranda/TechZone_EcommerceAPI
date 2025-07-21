using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Queries.GetAllCategoryQuery
{
    public sealed record GetAllCategoryQuery():IRequest<Response<IEnumerable<CategoryDto>>>;
}
