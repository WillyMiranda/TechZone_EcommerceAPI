using TechZone.Ecommerce.Domain.Common;

namespace TechZone.Ecommerce.Domain.Entities
{
    public sealed class Category: BaseAuditableEntity
    {
        public required string Name { get; set; }
        public string? Image { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}
