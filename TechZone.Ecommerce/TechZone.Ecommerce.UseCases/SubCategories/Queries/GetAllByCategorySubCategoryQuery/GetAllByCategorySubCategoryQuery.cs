using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Queries.GetAllByCategorySubCategoryQuery
{
    public sealed record GetAllByCategorySubCategoryQuery : IRequest<Response<IEnumerable<SubCategoryDto>>>
    {
        public Guid CategoryId { get; init; }
    }
}
