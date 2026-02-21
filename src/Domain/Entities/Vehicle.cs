namespace Renting.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; private set; }
    public string Brand { get; private set; } = string.Empty;
    public string Model { get; private set; } = string.Empty;
    public DateTime ManufactureDate { get; private set; }

    public Vehicle(Guid id, string brand, string model, DateTime manufactureDate)
    {
        Id = id;
        Brand = brand;
        Model = model;
        ManufactureDate = manufactureDate;
    }

    public bool IsValidForFleet() { var age = DateTime.UtcNow.Year - ManufactureDate.Year; return age <= 5; }
}
