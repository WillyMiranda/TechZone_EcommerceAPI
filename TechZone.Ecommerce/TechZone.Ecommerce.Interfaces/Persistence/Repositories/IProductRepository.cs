using TechZone.Ecommerce.Domain.Entities;

namespace TechZone.Ecommerce.Interfaces.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(Product product, DateTime createdAt, CancellationToken cancellation);
        Task<bool> UpdateAsync(Product product, DateTime updatedAt, CancellationToken cancellation);
        Task<bool> DeleteAsync(Guid id, DateTime updatedAt, CancellationToken cancellation);
    }
}
