using System.Text.Json.Serialization;

namespace TechZone.Ecommerce.WebApi.Modules.Feature
{
    public static class FeatureExtension
    {
        public static IServiceCollection AddFeatureServices(this IServiceCollection services)
        {
            const string policy = "TechZoneEcommercePolicy";
            services.AddCors(options =>
            {
                options.AddPolicy(policy, builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            //casteo automatico de enums a string
            services.AddControllers().AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });
            return services;
        }
    }
}
