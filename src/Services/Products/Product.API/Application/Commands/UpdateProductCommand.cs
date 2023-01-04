namespace Catalog.API.Application.Commands;

[DataContract]
public class UpdateProductCommand
    : IRequest<bool>
{
    [DataMember]
    public int Id { get; private set; }
    
    [DataMember]
    public string Name { get; private set; }

    [DataMember]
    public string Description { get; private set; }

    [DataMember]
    public decimal Price { get; private set; }

    [DataMember]
    public int? CategoryId { get; private set; }

    public UpdateProductCommand(int id, string name, string description, decimal price, int? categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }


}
