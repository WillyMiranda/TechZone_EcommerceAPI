using TechZone.Ecommerce.Domain.Common;

namespace TechZone.Ecommerce.Domain.Entities
{
    public sealed class SubCategory : BaseAuditableEntity
    {
        public required string Name { get; set; }
        public string? Image { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
