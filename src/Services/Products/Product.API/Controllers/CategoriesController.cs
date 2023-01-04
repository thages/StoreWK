namespace Catalog.API.Controllers;

using Catalog.API.Application.Queries;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CategoriesController> _logger;
    private readonly ICategoryQueries _categoryQueries;

    public CategoriesController(IMediator mediator, 
        ILogger<CategoriesController> logger,
        ICategoryQueries categoryQueries)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _categoryQueries = categoryQueries ?? throw new ArgumentNullException(nameof(categoryQueries));
    }


    [Route("create")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryCommand command)
    {
        bool commandResult = false;

        commandResult = await _mediator.Send(command);

        if (!commandResult)
        {
            return BadRequest();
        }

        return Ok();
    }


    [Route("categoryId:int")]
    [HttpGet]
    [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetCategoryAsync(int categoryId)
    {
        try
        {
            var category = await _categoryQueries.GetCategoryAsync(categoryId);
            return Ok(category);
        }
        catch
        {
            return NotFound();
        }
    }

    [Route("categoryId:int")]
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> DeleteProductAsync(int categoryId)
    {
        var requestDeleteCategory = new DeleteCategoryCommand(categoryId);

        _logger.LogInformation("--- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
            requestDeleteCategory.GetGenericTypeName(),
            nameof(requestDeleteCategory.CategoryId),
            requestDeleteCategory.CategoryId,
            requestDeleteCategory);

        bool commandResult = await _mediator.Send(requestDeleteCategory);

        if (!commandResult)
        {
            return BadRequest();
        }

        return Ok();

    }

    [Route("list")]
    [HttpGet]
    [ProducesResponseType(typeof(List<Category>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> ListCategoriesAsync()
    {
        try
        {
            var categories = await _categoryQueries.GetCategoriesAsync();
            return Ok(categories);
        }
        catch
        {
            return NotFound();
        }
    }
}
