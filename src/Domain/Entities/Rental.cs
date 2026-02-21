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
        Id = id;
        VehicleId = vehicleId;
        CustomerId = customerId;
        StartDate = startDate;
    }

    public void Close(DateTime endDate)
    {
        EndDate = endDate;
    }
}
