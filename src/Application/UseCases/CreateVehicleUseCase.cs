using Renting.Application.Dtos;
using Renting.Application.Repositories;
using Renting.Domain.Entities;

namespace Renting.Application.UseCases;

public class CreateVehicleUseCase
{
    private readonly IVehicleRepository _vehicleRepository;

    public CreateVehicleUseCase(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<CreateVehicleResponse> ExecuteAsync(CreateVehicleRequest request)
    {
        var vehicle = new Vehicle(
            Guid.NewGuid(),
            request.Brand,
            request.Model,
            request.ManufactureDate
        );

        await _vehicleRepository.AddAsync(vehicle);

        return new CreateVehicleResponse
        {
            Id = vehicle.Id,
            Brand = vehicle.Brand,
            Model = vehicle.Model
        };
    }
}
