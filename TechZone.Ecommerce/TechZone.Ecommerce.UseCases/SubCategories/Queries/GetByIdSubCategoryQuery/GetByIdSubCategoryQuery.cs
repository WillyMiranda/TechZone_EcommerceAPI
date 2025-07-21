using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Queries.GetByIdSubCategoryQuery
{
    public sealed record GetByIdSubCategoryQuery: IRequest<Response<SubCategoryDto>>
    {
        public Guid Id { get; init; }
    }
}
