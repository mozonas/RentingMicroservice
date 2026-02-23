using Renting.Application.Services.Vehicles;
using Renting.Domain.Repositories;
using Renting.Infrastructure.Repositories;
using Scalar.AspNetCore; // necesario para MapScalarApiReference
using Renting.Application.Services.Customers;

var builder = WebApplication.CreateBuilder(args);

// OpenAPI
builder.Services.AddOpenApi();

// Repositorios
builder.Services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();

// Servicios de aplicación
builder.Services.AddScoped<CreateVehicleService>();
builder.Services.AddScoped<ListAvailableVehiclesService>();
builder.Services.AddScoped<GetVehicleByIdService>();
builder.Services.AddScoped<GetCustomerByIdService>();

builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
builder.Services.AddScoped<CreateCustomerService>();
builder.Services.AddScoped<GetCustomerByIdService>();


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
app.MapGet("/vehicles/available", async (
    ListAvailableVehiclesService service,
    CancellationToken cancellationToken) =>
{
    var result = await service.ExecuteAsync(cancellationToken);
    return Results.Ok(result);
});

app.MapGet("/vehicles/{id:guid}", async (
    Guid id,
    GetVehicleByIdService service,
    CancellationToken cancellationToken) =>
{
    try
    {
        var result = await service.ExecuteAsync(id, cancellationToken);
        return Results.Ok(result);
    }
    catch (KeyNotFoundException ex)
    {
        return Results.NotFound(new { message = ex.Message });
    }
});
app.MapPut("/vehicles/{id:guid}/availability", async (
    Guid id,
    bool isAvailable,
    UpdateVehicleAvailabilityService service,
    CancellationToken cancellationToken) =>
{
    try
    {
        var result = await service.ExecuteAsync(id, isAvailable, cancellationToken);
        return Results.Ok(result);
    }
    catch (KeyNotFoundException ex)
    {
        return Results.NotFound(new { message = ex.Message });
    }
});

/*Endpoint: crear cliente*/ 
app.MapPost("/customers", async ( CreateCustomerRequest request, CreateCustomerService service, CancellationToken cancellationToken) => { var result = await service.ExecuteAsync( request.Name, request.DocumentId, cancellationToken); return Results.Created($"/customers/{result.Id}", result); }); app.MapGet("/customers/{id:guid}", async ( Guid id, GetCustomerByIdService service, CancellationToken cancellationToken) => { try { var result = await service.ExecuteAsync(id, cancellationToken); return Results.Ok(result); } catch (KeyNotFoundException ex) { return Results.NotFound(new { message = ex.Message }); } });

app.Run();
