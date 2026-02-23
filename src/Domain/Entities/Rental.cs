namespace Renting.Domain.Entities;

public class Rental
{
    public Guid Id { get; private set; }
    public Guid VehicleId { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    public bool IsActive => EndDate == null;

    public Rental(Guid id, Guid vehicleId, Guid customerId, DateTime startDate)
    {
        if (startDate > DateTime.UtcNow)
            throw new InvalidOperationException("La fecha de inicio no puede ser futura.");

        Id = id;
        VehicleId = vehicleId;
        CustomerId = customerId;
        StartDate = startDate;
        EndDate = null;
    }

    public void Close(DateTime endDate)
    {
        if (!IsActive)
            throw new InvalidOperationException("El alquiler ya está cerrado.");

        if (endDate < StartDate)
            throw new InvalidOperationException("La fecha de devolución no puede ser anterior a la fecha de inicio.");

        EndDate = endDate;
    }
}
