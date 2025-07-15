using Asp.Versioning.ApiExplorer;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.Persistence;
using TechZone.Ecommerce.UseCases;
using TechZone.Ecommerce.WebApi.Modules.Authentication;
using TechZone.Ecommerce.WebApi.Modules.Feature;
using TechZone.Ecommerce.WebApi.Modules.Injection;
using TechZone.Ecommerce.WebApi.Modules.Middleware;
using TechZone.Ecommerce.WebApi.Modules.Swagger;
using TechZone.Ecommerce.WebApi.Modules.Versioning;
using TechZone.Ecommerce.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//agregar servicios de capas logicas
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

//agregar servicios de modulos
builder.Services.AddAuthenticationServices();
builder.Services.AddFeatureServices();
builder.Services.AddInjectionServices();
builder.Services.AddApiVersioningServices();
builder.Services.AddSwaggerServices();

var app = builder.Build();

//agregar servicios de middleware
app.AddMiddlewareServices();

//datos semilla
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedDataService.InitializeAsync(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {

        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"TechZone Ecommerce API {description.GroupName.ToUpperInvariant()}");

        }
    });
    app.MapSwagger();
}

app.UseHttpsRedirection();

app.UseCors("TechZoneEcommercePolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//mapear puntos finales de identidad
app.MapIdentityApi<User>();

app.Run();
