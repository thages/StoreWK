namespace Catalog.API.Application.Queries;

public class ProductQueries
    : IProductQueries
{
    private string _connectionString = string.Empty;

    public ProductQueries(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
    }


    public async Task<Product> GetProductAsync(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        return await connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM products  WHERE Id=@id", new { id });
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        return await connection.QueryAsync<Product>("SELECT * FROM products");
    }

    public async Task<PageableResult<ProductPageableListItem>> ProductsPageableList(ProductPageableListParams searchParams)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var query = await connection.QueryAsync<dynamic>(@"SELECT p.id, p.name, p.description, p.price, c.name as category 
                            FROM products p
                            LEFT JOIN categories c ON p.categoryId = c.Id");

        var products = query.Skip(searchParams.Skip).Take(searchParams.PageSize).ToList();

        query = searchParams.OrderBy switch
        {
            ProductPageableListOrderOptions.NAME_ASC => query.OrderBy(e => e.Name),
            ProductPageableListOrderOptions.NAME_DESC => query.OrderByDescending(e => e.Name),
            _ => throw new ArgumentOutOfRangeException("Out of Range")
        };
        
        return new PageableResult<ProductPageableListItem>(
            pageSize: searchParams.PageSize,
            currentPage: searchParams.CurrentPage,
            results: MapPageableItems(products));
    }
    
    private List<ProductPageableListItem> MapPageableItems(List<dynamic> products)
    {
        List<ProductPageableListItem> results = new();

        foreach (var product in products)
        {
            results.Add(
                new ProductPageableListItem(
                    id: product.id,
                    name: product.name,
                    description: product.description,
                    price: product.price,
                    category: product.category));
        }

        return results;
    }
}
