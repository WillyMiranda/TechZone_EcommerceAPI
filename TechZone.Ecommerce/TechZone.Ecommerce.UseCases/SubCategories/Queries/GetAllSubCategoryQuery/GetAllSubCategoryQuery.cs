using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Queries.GetAllSubCategoryQuery
{
    public sealed record GetAllSubCategoryQuery():IRequest<Response<IEnumerable<SubCategoryDto>>>;
}
