namespace TechZone.Ecommerce.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;

    }
}
