using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.Persistence;
using TechZone.Ecommerce.WebApi.Modules.Authentication;
using TechZone.Ecommerce.WebApi.Modules.Feature;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//agregar servicios de capas logicas
builder.Services.AddPersistenceServices(builder.Configuration);

//agregar servicios de modulos
builder.Services.AddAuthenticationServices();
builder.Services.AddFeatureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("TechZoneEcommercePolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//mapear puntos finales de identidad
app.MapIdentityApi<User>();

app.Run();
