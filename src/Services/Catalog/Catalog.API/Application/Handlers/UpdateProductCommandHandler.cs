namespace Catalog.API.Application.Handlers;


using Domain.AggregatesModel.ProductAggregate;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<UpdateProductCommandHandler> _logger;
    
    public UpdateProductCommandHandler(
        IProductRepository productRepository,
        ILogger<UpdateProductCommandHandler> logger)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {

        var productToUpdate = await _productRepository.FindByIdAsync(command.Id);
        
               
        if (!productToUpdate)
        {
            return false;
        }

        _logger.LogInformation("----- Updating Product - Product: {@Product}", productToUpdate);

        productToUpdate.SetProductNewValues(
            name: command.Name,
            description: command.Description,
            price: command.Price,
            categoryId: command.CategoryId
        );

        var teste = _productRepository.Update(productToUpdate);

        return await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
