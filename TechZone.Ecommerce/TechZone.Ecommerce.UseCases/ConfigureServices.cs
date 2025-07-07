using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TechZone.Ecommerce.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add AutoMapper
            services.AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));

            //servicios de mediarr
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(DataValidationBehaviour<,>));
            });

            // Add Repositories
            return services;
        }
    }
}
