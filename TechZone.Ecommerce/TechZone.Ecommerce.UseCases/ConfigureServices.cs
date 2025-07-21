using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TechZone.Ecommerce.UseCases.Common.Behaviours;

namespace TechZone.Ecommerce.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add AutoMapper
            services.AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));

            //obtener las validaciones fluent de manera dinamica en tiempo de ejecucion
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //servicios de mediarr
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(DataValidationBehaviour<,>));
            });

            // Add Repositories
            return services;
        }
    }
}
