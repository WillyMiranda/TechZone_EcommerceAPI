using Dapper;
using Dapper.Transaction;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.Interfaces.Persistence.Repositories;
using TechZone.Ecommerce.Persistence.Contexts;

namespace TechZone.Ecommerce.Persistence.Repositories
{
    internal sealed class SubCategoryRepository(DapperContext _context) : ISubCategoryRepository
    {
        public async Task<bool> AddAsync(SubCategory subCategory, DateTime createdAt, CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            using var transaction = connection.BeginTransaction();
            try
            {
                var query = @"INSERT INTO SubCategories 
                                (Id, Name, Image, CreatedAt, CategoryId) VALUES 
                                (@Id, @Name, @Image, @CreatedAt, @CategoryId);";
                var parameters = new DynamicParameters();
                parameters.Add("Id", subCategory.Id.ToByteArray());
                parameters.Add("Name", subCategory.Name);
                parameters.Add("Image", subCategory.Image);
                parameters.Add("CreatedAt", createdAt);
                parameters.Add("CategoryId", subCategory.CategoryId.ToByteArray());

                var result = await transaction.ExecuteAsync(query, parameters);
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Un error ocurrió mientras se agregaba una sub-categoría: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(Guid id, DateTime updatedAt, CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            using var transaction = connection.BeginTransaction();
            try
            {
                var query = @"
                    UPDATE SubCategories
                    SET IsDeleted = TRUE,
                        UpdatedAt = @UpdatedAt
                    WHERE Id = @Id;";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id.ToByteArray());
                parameters.Add("UpdatedAt", updatedAt);

                var result = await transaction.ExecuteAsync(query, parameters);
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Un error ocurrió mientras se eliminaba una sub-categoría: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(SubCategory subCategory, DateTime updatedAt, CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            using var transaction = connection.BeginTransaction();
            try
            {
                var query = @"
                    UPDATE SubCategories
                    SET Name = @Name,
                        Image = @Image,
                        IsActive = @IsActive,
                        UpdatedAt = @UpdatedAt,
                        CategoryId = @CategoryId
                    WHERE Id = @Id;";
                var parameters = new DynamicParameters();
                parameters.Add("Id", subCategory.Id.ToByteArray());
                parameters.Add("Name", subCategory.Name);
                parameters.Add("Image", subCategory.Image);
                parameters.Add("UpdatedAt", updatedAt);
                parameters.Add("IsActive", subCategory.IsActive);
                parameters.Add("CategoryId", subCategory.CategoryId.ToByteArray());

                var result = await transaction.ExecuteAsync(query, parameters);
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Un error ocurrió mientras se actualizaba una sub-categoría: {ex.Message}", ex);
            }
        }
    }
}
