namespace Catalog.API.Application.Handlers;

using Catalog.Domain.AggregatesModel.CategoryAggregate;
public class CreateCategoryCommandHandler 
    : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<CreateCategoryCommandHandler> _logger;

    public CreateCategoryCommandHandler(IMediator mediator,
        ICategoryRepository categoryRepository,
        ILogger<CreateCategoryCommandHandler> logger)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(CreateCategoryCommand message, CancellationToken cancellationToken)
    {
        var category = new Category(message.Name, message.Description);

        _logger.LogInformation("----- Creating Category - Category: {@Category}", category);

        _categoryRepository.Add(category);

        return await _categoryRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
    }
}
