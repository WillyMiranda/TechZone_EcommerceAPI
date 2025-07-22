using Dapper;
using Microsoft.EntityFrameworkCore;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence.Services;
using TechZone.Ecommerce.Persistence.Contexts;

namespace TechZone.Ecommerce.Persistence.Services
{
    internal sealed class ProductService(DapperContext _context) : IProductService
    {
        public async Task<(IEnumerable<ProductDto> List, int TotalRecords)> GetAllAsync(string? productName, Guid? categoryId, Guid? subCategoryId, int pageNumber, int pageSize, CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            // Calcular el número de registros a saltar
            int skip = (pageNumber - 1) * pageSize;

            //listado de productos
            var query = @"
                SELECT 
	                p.*,c.Name AS CategoryName,sc.Name AS SubCategoryName
                FROM Products AS p
	                INNER JOIN Categories AS c ON p.CategoryId = c.Id
                    LEFT JOIN SubCategories AS sc ON p.SubCategoryId = sc.Id
                WHERE
	                p.IsDeleted=0
                    AND (@ProductName IS NULL OR p.Name LIKE CONCAT('%',@ProductName,'%'))
                    AND (@CategoryId IS NULL OR c.Id = @CategoryId)
                    AND (@SubCategoryId IS NULL OR sc.Id = @SubCategoryId)
                ORDER BY p.CreatedAt DESC
                LIMIT @PageSize OFFSET @Skip;";
            //conteo de productos
            var count = @"
                SELECT 
	                IFNULL(COUNT(p.Id), 0)
                FROM Products AS p
	                INNER JOIN Categories AS c ON p.CategoryId = c.Id
                    LEFT JOIN SubCategories AS sc ON p.SubCategoryId = sc.Id
                WHERE
	                p.IsDeleted=0
                    AND (@ProductName IS NULL OR p.Name LIKE CONCAT('%',@ProductName,'%'))
                    AND (@CategoryId IS NULL OR c.Id = @CategoryId)
                    AND (@SubCategoryId IS NULL OR sc.Id = @SubCategoryId);";

            var parameters = new DynamicParameters();
            parameters.Add("ProductName", productName);
            parameters.Add("CategoryId", categoryId.HasValue ? categoryId.Value.ToByteArray() : null);
            parameters.Add("SubCategoryId", subCategoryId.HasValue ? subCategoryId.Value.ToByteArray() : null);
            parameters.Add("PageSize", pageSize);
            parameters.Add("Skip", skip);
            var countResult = await connection.ExecuteScalarAsync<int>(count, parameters);
            var result = await connection.QueryAsync<ProductDto>(query, parameters);
            return (result, countResult);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id, CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            var query = @"
                SELECT 
	                p.*,c.Name AS CategoryName,sc.Name AS SubCategoryName
                FROM Products AS p
	                INNER JOIN Categories AS c ON p.CategoryId = c.Id
                    LEFT JOIN SubCategories AS sc ON p.SubCategoryId = sc.Id
                WHERE p.Id = @Id AND p.IsDeleted=0;";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id.ToByteArray());

            var result = await connection.QueryAsync<ProductDto>(query, parameters);
            return result.FirstOrDefault();
        }
    }
}
