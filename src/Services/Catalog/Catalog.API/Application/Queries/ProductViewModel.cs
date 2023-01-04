namespace Catalog.API.Application.Queries;

public record Product 
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int CategoryId { get; init; }
    public DateTime CreatedAt { get; init; }
}

