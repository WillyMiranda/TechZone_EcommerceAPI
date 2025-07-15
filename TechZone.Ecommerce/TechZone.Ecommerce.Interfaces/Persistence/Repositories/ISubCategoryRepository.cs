using TechZone.Ecommerce.Domain.Entities;

namespace TechZone.Ecommerce.Interfaces.Persistence.Repositories
{
    public interface ISubCategoryRepository
    {
        Task<bool> AddAsync(SubCategory subCategory, DateTime createdAt, CancellationToken cancellation);
        Task<bool> UpdateAsync(SubCategory subCategory, DateTime updatedAt, CancellationToken cancellation);
        Task<bool> DeleteAsync(Guid id, DateTime updatedAt, CancellationToken cancellation);
    }
}
