namespace TechZone.Ecommerce.DTOs.DTOs
{
    public sealed record CategoryDto
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public string? Image { get; init; }
        public bool IsActive { get; init; }
        public bool IsDeleted { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
