namespace Renting.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string DocumentId { get; private set; } = string.Empty;

    // Estado del cliente respecto a alquileres
    public bool HasActiveRental { get; private set; }

    public Customer(Guid id, string name, string documentId)
    {
        Id = id;
        Name = name;
        DocumentId = documentId;
        HasActiveRental = false;
    }

    public bool CanRent()
    {
        return !HasActiveRental;
    }

    public void RegisterRental()
    {
        if (HasActiveRental)
            throw new InvalidOperationException("El cliente ya tiene un alquiler activo.");

        HasActiveRental = true;
    }

    public void RegisterReturn()
    {
        if (!HasActiveRental)
            throw new InvalidOperationException("El cliente no tiene alquiler activo.");

        HasActiveRental = false;
    }
}
