namespace Renting.Application.Services.Vehicles;

public record VehicleResponse(
    Guid Id,
    string Brand,
    string Model,
    DateTime ManufactureDate,
    bool IsAvailable
);
