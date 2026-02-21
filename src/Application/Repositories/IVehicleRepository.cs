using Renting.Domain.Entities;

namespace Renting.Application.Repositories;


public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle);
    Task<Vehicle?> GetByIdAsync(Guid id);
    Task<IEnumerable<Vehicle>> GetAvailableAsync();
}
