namespace Catalog.API.Controllers;

using Catalog.API.Application.Queries;
using Catalog.API.Application.Queries.Products;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProductQueries _productQueries;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(
        IMediator mediator, 
        ILogger<ProductsController> logger, 
        IProductQueries productQueries)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productQueries = productQueries;
    }


    [Route("create")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command, CancellationToken token)
    {
        bool commandResult = await _mediator.Send(command, token);
        
        if (!commandResult)
        {
            return BadRequest();
        }

        return Ok();
    }

    [Route("productId:int")]
    [HttpGet]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetProductAsync(int productId)
    {
        try
        {
            var product = await _productQueries.GetProductAsync(productId);
            return Ok(product);
        }
        catch 
        {
            return NotFound();
        }
    }

    
    [Route("update")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command, CancellationToken token)
    {

        _logger.LogInformation("--- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
            command.GetGenericTypeName(),
            nameof(command.Id),
            command.Id,
            command);

        bool commandResult = await _mediator.Send(command, token);

        if (!commandResult)
        {
            return BadRequest();
        }

        return Ok();
    }

    [Route("productId:int")]
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> DeleteProductAsync(int productId)
    {
        var requestDeleteProduct = new DeleteProductCommand(productId);

        _logger.LogInformation("--- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
            requestDeleteProduct.GetGenericTypeName(),
            nameof(requestDeleteProduct.ProductId),
            requestDeleteProduct.ProductId,
            requestDeleteProduct);

        bool commandResult = await _mediator.Send(requestDeleteProduct);

        if (!commandResult)
        {
            return BadRequest();
        }
        
        return Ok();
        
    }

    [Route("pageable-list")]
    [HttpPost]
    [ProducesResponseType(typeof(PageableResult<ProductPageableListItem>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult> PageableList([FromBody] ProductPageableListQuery query, CancellationToken token)
    {
        return Ok(await _mediator.Send(query, token));
    }

}

