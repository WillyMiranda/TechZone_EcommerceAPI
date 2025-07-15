using Dapper;
using Microsoft.AspNetCore.Identity;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence.Services;
using TechZone.Ecommerce.Persistence.Contexts;

namespace TechZone.Ecommerce.Persistence.Services
{
    internal sealed class UserService(UserManager<User> _userManager, DapperContext _dapperContext): IUserService
    {
        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {
            using var connection = _dapperContext.Connection;
            const string sql = @"
                SELECT u.*, r.Name AS RoleName FROM AspNetUserRoles AS ur
	                INNER JOIN AspNetUsers AS u ON ur.UserId = u.Id
                    INNER JOIN AspNetRoles AS r ON ur.RoleId = r.Id
                WHERE u.Email = @Email;
                ";

            var parameters = new DynamicParameters();
            parameters.Add("Email", email);

            var users = await connection.QueryAsync<UserDto>(sql, parameters);

            return users.FirstOrDefault();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellation)
        {
            using var connection = _dapperContext.Connection;
            const string sql = @"
                SELECT u.*, r.Name AS RoleName FROM AspNetUserRoles AS ur
	                INNER JOIN AspNetUsers AS u ON ur.UserId = u.Id
                    INNER JOIN AspNetRoles AS r ON ur.RoleId = r.Id
                ORDER BY u.CreatedAt DESC;
                ";

            var users = await connection.QueryAsync<UserDto>(sql);

            return users;
        }
    }
}
