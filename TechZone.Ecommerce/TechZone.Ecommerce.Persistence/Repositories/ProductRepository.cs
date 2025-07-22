using Dapper;
using Dapper.Transaction;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.Interfaces.Persistence.Repositories;
using TechZone.Ecommerce.Persistence.Contexts;

namespace TechZone.Ecommerce.Persistence.Repositories
{
    internal sealed class ProductRepository(DapperContext _context) : IProductRepository
    {
        public async Task<bool> AddAsync(Product product, DateTime createdAt, CancellationToken cancellation)
        {
            using var connection = _context.Connection;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            using var transaction = connection.BeginTransaction();
            try
            {
                var query = @"INSERT INTO Products (
                    Id, Sku, Name, Price, Cost, Image, Stock, MinimunStock, FreeShipping, Featured,
                    Description, Specifications, IsActive, CreatedAt, CategoryId, SubCategoryId
                ) VALUES (
                    @Id, @Sku, @Name, @Price, @Cost, @Image, @Stock, @MinimunStock, @FreeShipping, @Featured,
                    @Description, @Specifications, @IsActive, @CreatedAt, @CategoryId, @SubCategoryId
                );";
                var parameters = new DynamicParameters();
                parameters.Add("Id", product.Id.ToByteArray());
                parameters.Add("Sku", product.Sku);
                parameters.Add("Name", product.Name);
                parameters.Add("Price", product.Price);
                parameters.Add("Cost", product.Cost);
                parameters.Add("Image", product.Image);
                parameters.Add("Stock", product.Stock);
                parameters.Add("MinimunStock", product.MinimumStock);
                parameters.Add("FreeShipping", product.FreeShipping);
                parameters.Add("Featured", product.Featured);
                parameters.Add("Description", product.Description);
                parameters.Add("Specifications", product.Specifications);
                parameters.Add("IsActive", product.IsActive);
                parameters.Add("CreatedAt", createdAt);
                parameters.Add("CategoryId", product.CategoryId.ToByteArray());
                parameters.Add("SubCategoryId", product.SubCategoryId.HasValue ? product.SubCategoryId.Value.ToByteArray() : null);

                var result = await transaction.ExecuteAsync(query, parameters);
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Un error ocurrió mientras se agregaba un producto: {ex.Message}", ex);
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
                    UPDATE Products
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
                throw new Exception($"Un error ocurrió mientras se eliminaba un producto: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(Product product, DateTime updatedAt, CancellationToken cancellation)
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
                    UPDATE Products
                    SET
                        Sku = @Sku,
                        Name = @Name,
                        Price = @Price,
                        Cost = @Cost,
                        Image = @Image,
                        Stock = @Stock,
                        MinimunStock = @MinimunStock,
                        FreeShipping = @FreeShipping,
                        Featured = @Featured,
                        Description = @Description,
                        Specifications = @Specifications,
                        IsActive = @IsActive,
                        UpdatedAt = @UpdatedAt,
                        CategoryId = @CategoryId,
                        SubCategoryId = @SubCategoryId
                    WHERE Id = @Id;";
                var parameters = new DynamicParameters();
                parameters.Add("Id", product.Id.ToByteArray());
                parameters.Add("Sku", product.Sku);
                parameters.Add("Name", product.Name);
                parameters.Add("Price", product.Price);
                parameters.Add("Cost", product.Cost);
                parameters.Add("Image", product.Image);
                parameters.Add("Stock", product.Stock);
                parameters.Add("MinimunStock", product.MinimumStock);
                parameters.Add("FreeShipping", product.FreeShipping);
                parameters.Add("Featured", product.Featured);
                parameters.Add("Description", product.Description);
                parameters.Add("Specifications", product.Specifications);
                parameters.Add("IsActive", product.IsActive);
                parameters.Add("UpdatedAt", updatedAt);
                parameters.Add("CategoryId", product.CategoryId.ToByteArray());
                parameters.Add("SubCategoryId", product.SubCategoryId.HasValue ? product.SubCategoryId.Value.ToByteArray() : null);

                var result = await transaction.ExecuteAsync(query, parameters);
                transaction.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Un error ocurrió mientras se actualizaba un producto: {ex.Message}", ex);
            }
        }
    }
}
