using Dapper;
using Dapper.Transaction;
using System.Data;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.Interfaces.Persistence.Repositories;
using TechZone.Ecommerce.Persistence.Contexts;

namespace TechZone.Ecommerce.Persistence.Repositories
{
    internal sealed class CategoryRepository(DapperContext _context) : ICategoryRepository
    {
        public async Task<bool> AddAsync(Category category, DateTime createdAt, CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            using var transaction = connection.BeginTransaction();
            try
            {
                var query = @"INSERT INTO Categories 
                                (Id, Name, Image, CreatedAt) VALUES 
                                (@Id, @Name, @Image, @CreatedAt);";
                var parameters = new DynamicParameters();
                parameters.Add("Id", category.Id.ToByteArray());
                parameters.Add("Name", category.Name);
                parameters.Add("Image", category.Image);
                parameters.Add("CreatedAt", createdAt);

                var result = await transaction.ExecuteAsync(query, parameters);
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Un error ocurrió mientras se agregaba una categoría: {ex.Message}", ex);
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
                    UPDATE Categories
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
                throw new Exception($"Un error ocurrió mientras se eliminaba una categoría: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(Category category, DateTime updatedAt, CancellationToken cancellation)
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
                    UPDATE Categories
                    SET Name = @Name,
                        Image = @Image,
                        IsActive = @IsActive,
                        UpdatedAt = @UpdatedAt
                    WHERE Id = @Id;";
                var parameters = new DynamicParameters();
                parameters.Add("Id", category.Id.ToByteArray());
                parameters.Add("Name", category.Name);
                parameters.Add("Image", category.Image);
                parameters.Add("UpdatedAt", updatedAt);
                parameters.Add("IsActive", category.IsActive);

                var result = await transaction.ExecuteAsync(query, parameters);
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Un error ocurrió mientras se actualizaba una categoría: {ex.Message}", ex);
            }
        }
    }
}
