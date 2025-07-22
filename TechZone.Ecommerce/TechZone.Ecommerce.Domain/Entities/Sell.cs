using TechZone.Ecommerce.Domain.Common;
using TechZone.Ecommerce.Domain.Enums;

namespace TechZone.Ecommerce.Domain.Entities
{
    public sealed class Sell: BaseAuditableEntity
    {
        public int Correlative { get; set; }
        public DateTime Date { get; set; }
        public SellType Type { get; set; } // CCF, CF, EXP
        public SellCondition Condition { get; set; } // CREDIT, CASH, CREDIT_CARD
        public SellStatus Status { get; set; } // PENDING, PAID, CANCELLED, REFUNDED
        public Guid UserId { get; set; }
        public User? User { get; set; }

    }
}
