using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using TechZone.Ecommerce.Domain.Entities;

namespace TechZone.Ecommerce.WebApi.Modules.Authentication
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
        {
            //permitir el acceso a HttpContext en toda la aplicacion para acceder a los claims en el token
            services.AddHttpContextAccessor();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            services.AddAuthentication();

            services.AddAuthorization();

            //activar apis de identidad
            services.AddIdentityApiEndpoints<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
            });
            services.AddOptions<BearerTokenOptions>(IdentityConstants.BearerScheme).Configure(options => {
                options.BearerTokenExpiration = TimeSpan.FromMinutes(30);
            });

            return services;
        }
    }
}
