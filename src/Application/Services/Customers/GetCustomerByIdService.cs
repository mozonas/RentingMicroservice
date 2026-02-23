using Renting.Domain.Repositories;

namespace Renting.Application.Services.Customers;

public class GetCustomerByIdService
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponse> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetByIdAsync(id, cancellationToken);

        if (customer is null)
            throw new KeyNotFoundException($"Customer with id '{id}' was not found.");

        return new CustomerResponse(
            customer.Id,
            customer.Name,
            customer.DocumentId,
            customer.HasActiveRental
        );
    }
}
