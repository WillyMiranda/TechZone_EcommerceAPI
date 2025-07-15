using Dapper;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence.Services;
using TechZone.Ecommerce.Persistence.Contexts;

namespace TechZone.Ecommerce.Persistence.Services
{
    internal sealed class SubCategoryService(DapperContext _context) : ISubCategoryService
    {
        public async Task<IEnumerable<SubCategoryDto>> GetAllAsync(CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            var query = @"
                SELECT sc.*, c.Name AS CategoryName FROM SubCategories AS sc
	                INNER JOIN Categories AS c ON sc.CategoryId = c.Id
                WHERE sc.IsDeleted=0;";
            var result = await connection.QueryAsync<SubCategoryDto>(query);
            return result;
        }

        public async Task<SubCategoryDto> GetByIdAsync(Guid id, CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            var query = @"
                SELECT sc.*, c.Name AS CategoryName FROM SubCategories AS sc
	                INNER JOIN Categories AS c ON sc.CategoryId = c.Id
                WHERE sc.IsDeleted=0 AND sc.Id = @Id;";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var result = await connection.QueryAsync<SubCategoryDto>(query, parameters);
            return result.FirstOrDefault();
        }
    }
}
