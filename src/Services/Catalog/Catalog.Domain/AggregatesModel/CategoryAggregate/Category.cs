namespace Catalog.Domain.AggregatesModel.CategoryAggregate;

public class Category : Entity, IAggregateRoot
{
    private string _name;
    private string _description;
    private DateTime _createdAt;

    public Category(string name, string description)
    {
        _name = name;
        _description = description;
        _createdAt = DateTime.UtcNow;
    }

    public void SetCategoryNewValues(string name, string description)
    {
        _name = name;
        _description = description;
    }
}
