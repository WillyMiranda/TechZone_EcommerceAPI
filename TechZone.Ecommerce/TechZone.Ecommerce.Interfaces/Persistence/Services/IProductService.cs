using TechZone.Ecommerce.DTOs.DTOs;

namespace TechZone.Ecommerce.Interfaces.Persistence.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(Guid id, CancellationToken cancellation);
        Task<(IEnumerable<ProductDto> List, int TotalRecords)> GetAllAsync(string? productName, Guid? categoryId, Guid? subCategoryId, int pageNumber, int pageSize, CancellationToken cancellation);
    }
}
