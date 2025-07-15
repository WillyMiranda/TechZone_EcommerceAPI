using TechZone.Ecommerce.Domain.Common;

namespace TechZone.Ecommerce.Domain.Entities
{
    public sealed class Reviews: BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
    }
}
