using TechZone.Ecommerce.Interfaces.Services;
using TechZone.Ecommerce.WebApi.Modules.GlobalException;
using TechZone.Ecommerce.WebApi.Services;

namespace TechZone.Ecommerce.WebApi.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionServices(this IServiceCollection services)
        {
            //middleware de manejo global de excepciones
            services.AddTransient<GlobalExceptionHandler>();
            services.AddScoped(typeof(ICurrentUser), typeof(CurrentUser));
            return services;
        }
    }
}
