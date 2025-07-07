using Microsoft.AspNetCore.Identity;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.Interfaces.Persistence.Repositories;

namespace TechZone.Ecommerce.WebApi.Services
{
    public static class SeedDataService
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            try
            {
                // Crear rol si no existe
                var roleManager = serviceProvider.GetRequiredService<RoleManager<UserRole>>();
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    var role = new UserRole { Name = "Admin", ConcurrencyStamp = Guid.NewGuid().ToString() };
                    
                    await roleManager.CreateAsync(role);
                    await roleManager.UpdateNormalizedRoleNameAsync(role);
                }
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    var role = new UserRole { Name = "User", ConcurrencyStamp = Guid.NewGuid().ToString() };

                    await roleManager.CreateAsync(role);
                    await roleManager.UpdateNormalizedRoleNameAsync(role);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inicializar los datos de prueba: {ex.Message}");
                throw;
            }
        }
    }
}
