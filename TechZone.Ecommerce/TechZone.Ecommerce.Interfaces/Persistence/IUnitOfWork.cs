using TechZone.Ecommerce.Interfaces.Persistence.Repositories;
using TechZone.Ecommerce.Interfaces.Persistence.Services;

namespace TechZone.Ecommerce.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IUserService UsersService { get; }
    }
}
