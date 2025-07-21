using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Queries.GetByIdCategoryQuery
{
    public sealed record GetByIdCategoryQuery: IRequest<Response<CategoryDto>>
    {
        public Guid Id { get; init; }
    }
}
