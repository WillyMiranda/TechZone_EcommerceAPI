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
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellation)
        {
            using var connection = _dapperContext.Connection;
            const string sql = @"
                SELECT * FROM AspNetUserRoles AS ur
	                INNER JOIN AspNetUsers AS u ON ur.UserId = u.Id
                    INNER JOIN AspNetRoles AS r ON ur.RoleId = r.Id
                ORDER BY u.CreatedAt DESC;
                ";

            var users = await connection.QueryAsync<UserDto>(sql);

            return users;
        }
    }
}
