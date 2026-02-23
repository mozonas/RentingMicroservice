using Renting.Domain.Entities;
using Renting.Domain.Repositories;

namespace Renting.Infrastructure.Repositories;

public class InMemoryVehicleRepository : IVehicleRepository
{
    private readonly List<Vehicle> _vehicles = new();

    public Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
    {
        _vehicles.Add(vehicle);
        return Task.CompletedTask;
    }

    public Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
        return Task.FromResult(vehicle);
    }

    public Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
    {
        // En memoria no hace falta hacer nada: la referencia ya está actualizada
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<Vehicle>> GetAvailableAsync(CancellationToken cancellationToken = default)
    {
        var available = _vehicles.Where(v => v.IsAvailable).ToList();
        return Task.FromResult((IReadOnlyList<Vehicle>)available);
    }
}
