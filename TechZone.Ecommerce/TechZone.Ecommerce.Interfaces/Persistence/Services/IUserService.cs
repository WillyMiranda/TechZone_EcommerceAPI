﻿using TechZone.Ecommerce.DTOs.DTOs;

namespace TechZone.Ecommerce.Interfaces.Persistence.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellation);
    }
}
