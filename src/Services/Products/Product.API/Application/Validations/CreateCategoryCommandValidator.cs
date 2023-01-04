namespace Catalog.API.Application.Validations;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(ILogger<CreateCategoryCommandValidator> logger)
    {
        RuleFor(command => command.Name).NotEmpty();
        
        logger.LogTrace("----- INSTANCIA CRIADA- {ClassName}", GetType().Name);
    }
}
