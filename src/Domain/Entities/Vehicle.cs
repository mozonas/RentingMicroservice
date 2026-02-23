namespace Renting.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; private set; }
    public string Brand { get; private set; } = string.Empty;
    public string Model { get; private set; } = string.Empty;
    public DateTime ManufactureDate { get; private set; }
    public bool IsAvailable { get; private set; }

    public Vehicle(Guid id, string brand, string model, DateTime manufactureDate)
    {
        Id = id;
        Brand = brand;
        Model = model;
        ManufactureDate = manufactureDate;

        if (!IsValidForFleet())
            throw new InvalidOperationException("El vehículo tiene más de 5 años y no puede añadirse a la flota.");

        IsAvailable = true;
    }

    public bool IsValidForFleet()
    {
        var age = DateTime.UtcNow.Date - ManufactureDate.Date;
        return age.TotalDays <= 5 * 365;
    }

    public void MarkAsRented()
    {
        if (!IsAvailable)
            throw new InvalidOperationException("El vehículo ya está alquilado.");

        IsAvailable = false;
    }

    public void MarkAsReturned()
    {
        if (IsAvailable)
            throw new InvalidOperationException("El vehículo ya está disponible.");

        IsAvailable = true;
    }

    public void UpdateAvailability(bool isAvailable)
    {
        IsAvailable = isAvailable;
    }

}
