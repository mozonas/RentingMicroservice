namespace Renting.Application.Dtos;

public class CreateVehicleRequest
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateTime ManufactureDate { get; set; }
}
