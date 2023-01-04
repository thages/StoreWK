namespace Catalog.API.Application.Validations;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{

    public CreateProductCommandValidator(ILogger<CreateProductCommandValidator> logger)
    {
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.Price).NotEmpty().GreaterThan(0).WithMessage("O preço deve ser diferente de zero."); ;
        
        logger.LogTrace("----- INSTANCIA CRIADA- {ClassName}", GetType().Name);
    }
}
