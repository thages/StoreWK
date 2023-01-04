namespace Catalog.API.Application.Handlers;

using Catalog.Domain.AggregatesModel.ProductAggregate;

public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<DeleteProductCommandHandler> _logger;
    public DeleteProductCommandHandler(
        IProductRepository productRepository,
        ILogger<DeleteProductCommandHandler> logger)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {

        var productToDelete = await _productRepository.GetAsync(command.ProductId);
        
        if (!productToDelete)
        {
            return false;
        }
        
       _logger.LogInformation("----- Deleting Product - Product: {@Product}", productToDelete);

        _productRepository.Remove(productToDelete);

        return await _productRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
    }
}
