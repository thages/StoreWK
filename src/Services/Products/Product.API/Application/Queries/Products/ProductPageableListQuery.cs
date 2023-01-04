namespace Catalog.API.Application.Queries.Products;

public class ProductPageableListQuery : ProductPageableListParams, IApplicationQuery<PageableResult<ProductPageableListItem>>
{
}
