namespace Renting.Application.Services.Vehicles;

public record CreateVehicleResponse(
    Guid Id,
    string Brand,
    string Model,
    DateTime ManufactureDate,
    bool IsAvailable
);
