using TechZone.Ecommerce.Domain.Common;
using TechZone.Ecommerce.Domain.Enums;

namespace TechZone.Ecommerce.Domain.Entities
{
    public sealed class Sell: BaseAuditableEntity
    {
        public int Correlative { get; set; }
        public DateTime Date { get; set; }
        //public decimal VATExcluded { get; set; }
        //public decimal VAT { get; set; }
        //public decimal Total => VATExcluded + VAT;
        public SellType Type { get; set; }
        public SellCondition Condition { get; set; }
        public SellStatus Status { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

    }
}
