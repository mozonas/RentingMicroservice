namespace Renting.Domain.Repositories;

using Renting.Domain.Entities;

public interface IRentalRepository
{
    Task<Rental?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Rental rental, CancellationToken cancellationToken = default);
    Task UpdateAsync(Rental rental, CancellationToken cancellationToken = default);
    Task<bool> CustomerHasActiveRentalAsync(Guid customerId, CancellationToken cancellationToken = default);
}
