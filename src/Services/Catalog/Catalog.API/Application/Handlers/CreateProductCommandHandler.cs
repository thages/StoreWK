namespace Catalog.API.Application.Handlers;

using Catalog.Domain.AggregatesModel.ProductAggregate;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(
        IProductRepository productRepository,
        ILogger<CreateProductCommandHandler> logger)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(CreateProductCommand message, CancellationToken cancellationToken)
    {
        var product = new Product(message.Name, message.Description, message.Price, message.CategoryId);

       _logger.LogInformation("----- Creating Product - Product: {@Product}", product);

        _productRepository.Add(product);

        return await _productRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
    }
}


