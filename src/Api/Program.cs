using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Activar OpenAPI nativo (.NET 10)
builder.Services.AddOpenApi();

var app = builder.Build();

// Endpoint JSON OpenAPI
app.MapOpenApi();

// UI de Scalar (versión 2.12.46)
app.MapScalarApiReference();

// Endpoint de prueba
app.MapGet("/", () => "API funcionando en .NET 10");

app.Run();
