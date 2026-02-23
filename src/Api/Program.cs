using Renting.Application.Services.Vehicles;
using Renting.Domain.Repositories;
using Renting.Infrastructure.Repositories;
using Scalar.AspNetCore; // necesario para MapScalarApiReference

var builder = WebApplication.CreateBuilder(args);

// OpenAPI
builder.Services.AddOpenApi();

// Repositorios
builder.Services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();

// Servicios de aplicación
builder.Services.AddScoped<CreateVehicleService>();

var app = builder.Build();

// OpenAPI + Scalar UI
app.MapOpenApi();
app.MapScalarApiReference(); // este SÍ funciona con el using correcto

// Endpoint: crear vehículo
app.MapPost("/vehicles", async (
    CreateVehicleRequest request,
    CreateVehicleService service,
    CancellationToken cancellationToken) =>
{
    var result = await service.ExecuteAsync(request, cancellationToken);
    return Results.Created($"/vehicles/{result.Id}", result);
});

app.Run();
