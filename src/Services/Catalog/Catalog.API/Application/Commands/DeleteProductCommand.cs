namespace Catalog.API.Application.Commands;

[DataContract]
public class DeleteProductCommand : IRequest<bool>
{
    [DataMember]
    public int ProductId { get; private set; }

    public DeleteProductCommand(int productId)
    {
        ProductId = productId;
    }

}
