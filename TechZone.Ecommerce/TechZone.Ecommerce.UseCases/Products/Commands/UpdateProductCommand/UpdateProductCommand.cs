using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Products.Commands.UpdateProductCommand
{
    public sealed record UpdateProductCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; } // Optional, for updates
        public required string Sku { get; init; }
        public required string Name { get; init; }
        public double Price { get; init; }
        public double Cost { get; init; }
        public required string Image { get; init; }
        public decimal Stock { get; init; }
        public decimal MinimumStock { get; init; }
        public bool FreeShipping { get; init; }
        public bool Featured { get; init; }
        public required string Description { get; init; }
        public required Dictionary<string, string> Specifications { get; init; }
        public Guid CategoryId { get; init; }
        public Guid? SubCategoryId { get; init; }
    }
}
