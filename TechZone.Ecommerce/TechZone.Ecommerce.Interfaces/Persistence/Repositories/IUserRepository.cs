﻿using TechZone.Ecommerce.Domain.Entities;

namespace TechZone.Ecommerce.Interfaces.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User user, string password, string role, CancellationToken cancellation);
        Task<bool> UpdateAsync(Guid userId, User user, string role, CancellationToken cancellation);
        Task<bool> SetLastAccessAsync(Guid userId, DateTime lastAccessAt, CancellationToken cancellation);
    }
}
