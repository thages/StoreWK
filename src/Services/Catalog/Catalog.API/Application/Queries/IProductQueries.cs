namespace Catalog.API.Application.Queries;

public interface IProductQueries
{
    Task<Product> GetProductAsync(int id);
    Task<IEnumerable<ProductPageableListItem>> GetProductsAsync();
    Task<PageableResult<ProductPageableListItem>> ProductsPageableList(ProductPageableListParams searchParams);
}
