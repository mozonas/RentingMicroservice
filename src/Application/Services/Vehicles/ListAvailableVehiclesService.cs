using Renting.Domain.Repositories;

namespace Renting.Application.Services.Vehicles;

public class ListAvailableVehiclesService
{
    private readonly IVehicleRepository _vehicleRepository;

    public ListAvailableVehiclesService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IReadOnlyList<VehicleResponse>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        var vehicles = await _vehicleRepository.GetAvailableAsync(cancellationToken);

        return vehicles
            .Select(v => new VehicleResponse(
                v.Id,
                v.Brand,
                v.Model,
                v.ManufactureDate,
                v.IsAvailable
            ))
            .ToList();
    }
}
