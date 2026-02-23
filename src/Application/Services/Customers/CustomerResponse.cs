namespace Renting.Application.Services.Customers;

public record CustomerResponse(
    Guid Id,
    string Name,
    string DocumentId,
    bool HasActiveRental
);
