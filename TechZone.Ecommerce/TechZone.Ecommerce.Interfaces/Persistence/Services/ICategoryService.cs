using TechZone.Ecommerce.DTOs.DTOs;

namespace TechZone.Ecommerce.Interfaces.Persistence.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetByIdAsync(Guid id, CancellationToken cancellation);
        Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken cancellation);
    }
}
