using TechZone.Ecommerce.Interfaces.Services;
using TechZone.Ecommerce.WebApi.Services;

namespace TechZone.Ecommerce.WebApi.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICurrentUser), typeof(CurrentUser));
            return services;
        }
    }
}
