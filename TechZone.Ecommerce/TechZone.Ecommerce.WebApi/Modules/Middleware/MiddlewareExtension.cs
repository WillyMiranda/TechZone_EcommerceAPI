using TechZone.Ecommerce.WebApi.Modules.GlobalException;

namespace TechZone.Ecommerce.WebApi.Modules.Middleware
{
    internal static class MiddlewareExtension
    {
        internal static IApplicationBuilder AddMiddlewareServices(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandler>();
            return app;
        }
    }
}
