namespace Renting.Application.Services.Vehicles;

public record CreateVehicleRequest(
    string Brand,
    string Model,
    DateTime ManufactureDate
);
