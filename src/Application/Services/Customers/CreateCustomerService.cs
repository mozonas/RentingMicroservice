using Renting.Domain.Entities;
using Renting.Domain.Repositories;

namespace Renting.Application.Services.Customers;

public class CreateCustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponse> ExecuteAsync(
        string name,
        string documentId,
        CancellationToken cancellationToken = default)
    {
        var customer = new Customer(Guid.NewGuid(), name, documentId);

        await _customerRepository.AddAsync(customer, cancellationToken);

        return new CustomerResponse(
            customer.Id,
            customer.Name,
            customer.DocumentId,
            customer.HasActiveRental
        );
    }
}
