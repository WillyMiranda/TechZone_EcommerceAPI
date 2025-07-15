using TechZone.Ecommerce.DTOs.DTOs;

namespace TechZone.Ecommerce.Interfaces.Persistence.Services
{
    public interface ISubCategoryService
    {
        Task<SubCategoryDto> GetByIdAsync(Guid id, CancellationToken cancellation);
        Task<IEnumerable<SubCategoryDto>> GetAllAsync(CancellationToken cancellation);
    }
}
