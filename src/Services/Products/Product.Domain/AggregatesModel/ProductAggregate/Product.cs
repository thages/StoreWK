namespace Catalog.Domain.AggregatesModel.ProductAggregate;

public class Product : Entity, IAggregateRoot
{
    private string _name;
    private string _description;
    private decimal _price;
    private int? _categoryId;
    private DateTime _createdAt;

    public Product(string name, string description, decimal price, int? categoryId)
    {
        _name = name;
        _description = description;
        _price = price;
        _categoryId = categoryId;
        _createdAt = DateTime.UtcNow;

        AddProductCreatedEvent();
    }

    private void AddProductCreatedEvent()
    {
        var productCreatedEvent = new ProductCreatedEvent(this);

        this.AddDomainEvent(productCreatedEvent);
    }

    public void SetProductNewValues(string name, string description, decimal price, int? categoryId)
    {
        _name = name;
        _description = description;
        _price = price;
        _categoryId = categoryId;
    }
    
}
