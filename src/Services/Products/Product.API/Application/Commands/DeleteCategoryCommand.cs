namespace Catalog.API.Application.Commands;

[DataContract]
public class DeleteCategoryCommand : IRequest<bool>
{
    [DataMember]
    public int CategoryId { get; private set; }

    public DeleteCategoryCommand(int categoryId)
    {
        CategoryId = categoryId;
    }

}
