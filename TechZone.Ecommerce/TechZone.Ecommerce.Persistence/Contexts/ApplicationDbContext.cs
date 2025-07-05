using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechZone.Ecommerce.Domain.Entities;

namespace TechZone.Ecommerce.Persistence.Contexts
{
    internal sealed class ApplicationDbContext: IdentityDbContext<User, UserRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //obtener las clases de configuración dinamicamente
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            //forzando el uso de guid como binary(16) en todas las propiedades de tipo Guid
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(Guid) || property.ClrType == typeof(Guid?))
                    {
                        property.SetColumnType("binary(16)");
                    }
                }
            }
        }
    }
}
