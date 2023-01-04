namespace Catalog.API.Application.Commands;

[DataContract]
public class CreateProductCommand
    : IRequest<bool>
{

    [DataMember]
    public string Name { get; private set; }

    [DataMember]
    public string Description { get; private set; }

    [DataMember]
    public decimal Price { get; private set; }

    [DataMember]
    public int CategoryId { get; private set; }

   public CreateProductCommand(string name, string description, decimal price, 
        int categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }
}
