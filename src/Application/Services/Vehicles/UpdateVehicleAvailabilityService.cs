using Renting.Domain.Repositories;
using Renting.Domain.Entities;

namespace Renting.Application.Services.Vehicles;

public class UpdateVehicleAvailabilityService
{
    private readonly IVehicleRepository _vehicleRepository;

    public UpdateVehicleAvailabilityService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<VehicleResponse> ExecuteAsync(
        Guid id,
        bool isAvailable,
        CancellationToken cancellationToken = default)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

        if (vehicle is null)
            throw new KeyNotFoundException($"Vehicle with id '{id}' was not found.");

        vehicle.UpdateAvailability(isAvailable);

        await _vehicleRepository.UpdateAsync(vehicle, cancellationToken);

        return new VehicleResponse(
            vehicle.Id,
            vehicle.Brand,
            vehicle.Model,
            vehicle.ManufactureDate,
            vehicle.IsAvailable
        );
    }
}
