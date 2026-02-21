namespace Renting.Application.Dtos;

public class CreateVehicleResponse
{
    public Guid Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
}
