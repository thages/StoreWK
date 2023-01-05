namespace Catalog.API.Application.Commands;

[DataContract]
public class UpdateCategoryCommand
    : IRequest<bool>
{

    [DataMember]
    public int Id { get; private set; }

    [DataMember]
    public string Name { get; private set; }

    [DataMember]
    public string Description { get; private set; }
    
    public UpdateCategoryCommand(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

}
