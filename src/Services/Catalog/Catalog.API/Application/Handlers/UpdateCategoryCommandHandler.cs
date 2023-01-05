namespace Catalog.API.Application.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<UpdateCategoryCommandHandler> _logger;

    public UpdateCategoryCommandHandler(
        ICategoryRepository categoryRepository,
        ILogger<UpdateCategoryCommandHandler> logger)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {

        var categoryToUpdate = await _categoryRepository.GetAsync(command.Id);


        if (!categoryToUpdate)
        {
            return false;
        }

        _logger.LogInformation("----- Updating Category - Category: {@Category}", categoryToUpdate);

        categoryToUpdate.SetCategoryNewValues(
            name: command.Name,
            description: command.Description
        );

        _ = _categoryRepository.Update(categoryToUpdate);

        return await _categoryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
