using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Products.Queries.GetByIdProductQuery
{
    public sealed record GetByIdProductQuery: IRequest<Response<ProductDto>>
    {
        public Guid Id { get; init; }
    }
}
