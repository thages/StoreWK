namespace Catalog.Domain.Events;

public class ProductUpdatedEvent
{
    public ProductUpdatedEvent(int id, string name, string description, decimal price, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        CreatedAt = createdAt;
    }

    public int Id { get; }
    public string Name { get; }
    public string Description { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }
}
