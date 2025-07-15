using Dapper;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence.Services;
using TechZone.Ecommerce.Persistence.Contexts;

namespace TechZone.Ecommerce.Persistence.Services
{
    internal sealed class CategoryService(DapperContext _context) : ICategoryService
    {
        public async Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            var query = @"SELECT * FROM Categories WHERE IsDeleted=0;";
            var result = await connection.QueryAsync<CategoryDto>(query);
            return result;
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id, CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            var query = @"SELECT * FROM Categories WHERE Id=@Id AND IsDeleted=0;";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id.ToByteArray());

            var result = await connection.QueryAsync<CategoryDto>(query, parameters);
            return result.FirstOrDefault();
        }
    }
}
