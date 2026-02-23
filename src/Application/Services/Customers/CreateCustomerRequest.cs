namespace Renting.Application.Services.Customers;

public record CreateCustomerRequest(
    string Name,
    string DocumentId
);
