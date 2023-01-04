namespace Catalog.API.Application.Queries;
public record Category
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime CreatedAt { get; init; }
}
