using Renting.Domain.Repositories;

namespace Renting.Application.Services.Vehicles;

public class GetVehicleByIdService
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehicleByIdService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<VehicleResponse> ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

        if (vehicle is null)
            throw new KeyNotFoundException($"Vehicle with id '{id}' was not found.");

        return new VehicleResponse(
            vehicle.Id,
            vehicle.Brand,
            vehicle.Model,
            vehicle.ManufactureDate,
            vehicle.IsAvailable
        );
    }
}
