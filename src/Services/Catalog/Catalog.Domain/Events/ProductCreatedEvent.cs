namespace Catalog.Domain.Events;

public class ProductCreatedEvent : INotification
{
    public Product Product { get;}
    
    public ProductCreatedEvent(Product product)
    {
        Product = product;
    }
}
