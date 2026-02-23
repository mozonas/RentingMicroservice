namespace Renting.Domain.Repositories;

using Renting.Domain.Entities;

public interface IVehicleRepository
{
    Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default);
    Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Vehicle>> GetAvailableAsync(CancellationToken cancellationToken = default);
}
