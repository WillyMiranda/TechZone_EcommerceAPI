using TechZone.Ecommerce.Domain.Common;

namespace TechZone.Ecommerce.Domain.Entities
{
    public sealed class Purchase: BaseAuditableEntity
    {
        public int Correlative { get; set; }
        public DateTime Date { get; set; }
        //public decimal VATExcluded { get; set; }
        //public decimal VAT { get; set; }
        //public decimal Total => VATExcluded + VAT;


        public Guid UserId { get; set; }
        public User? User { get; set; }

    }
}
