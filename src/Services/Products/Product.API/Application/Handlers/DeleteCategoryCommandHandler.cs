namespace Catalog.API.Application.Handlers
{
    public class DeleteCategoryCommandHandler
      : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;
        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            ILogger<DeleteCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {

            var categoryToDelete = await _categoryRepository.GetAsync(command.CategoryId);

            if (!categoryToDelete)
            {
                return false;
            }

            _logger.LogInformation("----- Deleting Category - Category: {@Category}", categoryToDelete);

            _categoryRepository.Remove(categoryToDelete);

            return await _categoryRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }

}

