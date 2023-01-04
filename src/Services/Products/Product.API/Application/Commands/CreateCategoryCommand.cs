namespace Catalog.API.Application.Commands;

[DataContract]
public class CreateCategoryCommand
  : IRequest<bool>
{

    [DataMember]
    public string Name { get; private set; }

    [DataMember]
    public string Description { get; private set; }
    
    public CreateCategoryCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
