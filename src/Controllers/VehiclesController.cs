using Microsoft.AspNetCore.Mvc;
using Renting.Application.Dtos;
using Renting.Application.UseCases;

namespace Renting.Api.Controllers;

[ApiController]
[Route("vehicles")]
public class VehiclesController : ControllerBase
{
    private readonly CreateVehicleUseCase _createVehicleUseCase;

    public VehiclesController(CreateVehicleUseCase createVehicleUseCase)
    {
        _createVehicleUseCase = createVehicleUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle(CreateVehicleRequest request)
    {
        var result = await _createVehicleUseCase.ExecuteAsync(request);
        return Ok(result);
    }
}
