using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Interfaces.Persistence.Repositories;
using TechZone.Ecommerce.Interfaces.Persistence.Services;

namespace TechZone.Ecommerce.Persistence
{
    internal sealed class UnitOfWork(
            IUserRepository users,
            IUserService usersService
        ) : IUnitOfWork
    {
        public IUserRepository Users => users;
        public IUserService UsersService => usersService;
    }
}
