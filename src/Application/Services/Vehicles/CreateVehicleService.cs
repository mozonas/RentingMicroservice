using Renting.Domain.Entities;
using Renting.Domain.Repositories;

namespace Renting.Application.Services.Vehicles;

public class CreateVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public CreateVehicleService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<CreateVehicleResponse> ExecuteAsync(
        CreateVehicleRequest request,
        CancellationToken cancellationToken = default)
    {
        var vehicle = new Vehicle(
            Guid.NewGuid(),
            request.Brand,
            request.Model,
            request.ManufactureDate
        );

        await _vehicleRepository.AddAsync(vehicle, cancellationToken);

        return new CreateVehicleResponse(
            vehicle.Id,
            vehicle.Brand,
            vehicle.Model,
            vehicle.ManufactureDate,
            vehicle.IsAvailable
        );
    }
}
