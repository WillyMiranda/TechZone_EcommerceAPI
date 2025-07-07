using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Interfaces.Persistence.Repositories;
using TechZone.Ecommerce.Interfaces.Persistence.Services;
using TechZone.Ecommerce.Persistence.Contexts;
using TechZone.Ecommerce.Persistence.Repositories;
using TechZone.Ecommerce.Persistence.Services;

namespace TechZone.Ecommerce.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DevConnection");
            //agregando y configurando el context de entity framework para conectar a la db
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //agregando contexto de base de datos de dapper
            services.AddSingleton<DapperContext>();

            //agregando servicio de autentificacion
            services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
            .AddRoles<UserRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();


            //servicio de unidad de trabajo
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            //repositorios - commands
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            //services - queries
            services.AddScoped(typeof(IUserService), typeof(UserService));


            return services;
        }
    }
}
