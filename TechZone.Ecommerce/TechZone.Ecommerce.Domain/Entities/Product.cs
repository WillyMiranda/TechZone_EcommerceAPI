using TechZone.Ecommerce.Domain.Common;

namespace TechZone.Ecommerce.Domain.Entities
{
    public sealed class Product : BaseAuditableEntity
    {
        public required string Sku { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        //public double Rating { get; set; }
        //public int Review { get; set; }
        public required string Image { get; set; }
        public decimal Stock { get; set; }
        public bool FreeShipping { get; set; }
        public bool Featured { get; set; }
        public required string Description { get; set; }
        public required Dictionary<string, string> Specifications { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
        public ICollection<Reviews>? Reviews { get; set; }
    }
}
