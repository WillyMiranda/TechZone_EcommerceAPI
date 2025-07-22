namespace TechZone.Ecommerce.DTOs.DTOs
{
    public sealed record ProductDto
    {
        public required Guid Id { get; init; }   
        public required string Sku { get; init; }
        public required string Name { get; init; }
        public required double Price { get; init; }
        public required double Cost { get; init; }
        public double Rating { get; init; }
        public int Review { get; init; }
        public required string Image { get; init; }
        public required decimal Stock { get; init; }
        public decimal MinimumStock { get; init; }
        public bool FreeShipping { get; init; }
        public bool Featured { get; init; }
        public required string Description { get; init; }
        public required Dictionary<string, string> Specifications { get; init; }
        public required DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public bool IsActive { get; init; }
        public required Guid CategoryId { get; init; }
        public string CategoryName { get; init; }
        public required Guid? SubCategoryId { get; init; }
        public string? SubCategoryName { get; init; }
    }
}
