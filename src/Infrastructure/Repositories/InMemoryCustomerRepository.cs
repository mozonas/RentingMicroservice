using Renting.Domain.Entities;
using Renting.Domain.Repositories;

namespace Renting.Infrastructure.Repositories;

public class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new();

    public Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        _customers.Add(customer);
        return Task.CompletedTask;
    }

    public Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(customer);
    }

    public Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        // En memoria no hace falta hacer nada
        return Task.CompletedTask;
    }
}
