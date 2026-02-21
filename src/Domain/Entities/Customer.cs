namespace Renting.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string DocumentId { get; private set; } = string.Empty;

    public Customer(Guid id, string name, string documentId)
    {
        Id = id;
        Name = name;
        DocumentId = documentId;
    }
}
