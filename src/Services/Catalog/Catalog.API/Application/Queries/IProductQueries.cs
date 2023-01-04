namespace Catalog.API.Application.Queries;

public interface IProductQueries
{
    Task<Product> GetProductAsync(int id);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<PageableResult<ProductPageableListItem>> ProductsPageableList(ProductPageableListParams searchParams);
}
