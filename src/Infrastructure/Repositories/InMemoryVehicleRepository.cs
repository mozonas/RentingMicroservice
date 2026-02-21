using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Renting.Application.Repositories;
using Renting.Domain.Entities;

namespace Renting.Infrastructure.Repositories;

public class InMemoryVehicleRepository : IVehicleRepository
{
    private readonly List<Vehicle> _vehicles = new();

    public Task AddAsync(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
        return Task.CompletedTask;
    }

    public Task<Vehicle?> GetByIdAsync(Guid id)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
        return Task.FromResult(vehicle);
    }

    public Task<IEnumerable<Vehicle>> GetAvailableAsync()
    {
        return Task.FromResult(_vehicles.AsEnumerable());
    }
}
