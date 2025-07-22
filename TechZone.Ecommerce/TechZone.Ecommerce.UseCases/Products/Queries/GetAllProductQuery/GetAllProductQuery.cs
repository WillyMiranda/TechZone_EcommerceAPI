using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Products.Queries.GetAllProductQuery
{
    public sealed record GetAllProductQuery: IRequest<ResponsePagination<IEnumerable<ProductDto>>>
    {
        public string? ProductName { get; init; }
        public Guid? CategoryId { get; init; }
        public Guid? SubCategoryId { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
