namespace Catalog.API.Application.Validations;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator(ILogger<DeleteProductCommandValidator> logger)
    {
        RuleFor(command => command.ProductId).NotEmpty().WithMessage("ProductId não encontrado");

        logger.LogTrace("----- INSTANCIA CRIADA- {ClassName}", GetType().Name);
    }
}
