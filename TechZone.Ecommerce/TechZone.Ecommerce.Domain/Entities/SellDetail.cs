using TechZone.Ecommerce.Domain.Common;

namespace TechZone.Ecommerce.Domain.Entities
{
    public sealed class SellDetail:BaseAuditableEntity
    {
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VAT { get; set; }
        public Guid SellId { get; set; }
        public Sell? Sell { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
