using Renting.Domain.Entities;

namespace Renting.Domain.Services;

public class RentalDomainService
{
    public bool CanRentVehicle(Customer customer, IEnumerable<Rental> rentals)
    {
        return !rentals.Any(r => r.CustomerId == customer.Id && r.IsActive);
    }
}
