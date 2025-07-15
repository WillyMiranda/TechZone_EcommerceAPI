using TechZone.Ecommerce.Domain.Entities;

namespace TechZone.Ecommerce.Interfaces.Persistence.Repositories
{
    public interface ICategoryRepository
    {
        Task<bool> AddAsync(Category category, DateTime createdAt, CancellationToken cancellation);
        Task<bool> UpdateAsync(Category category, DateTime updatedAt, CancellationToken cancellation);
        Task<bool> DeleteAsync(Guid id, DateTime updatedAt, CancellationToken cancellation);
    }
}
