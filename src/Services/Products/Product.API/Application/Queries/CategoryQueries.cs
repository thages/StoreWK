namespace Catalog.API.Application.Queries;

public class CategoryQueries : ICategoryQueries
{
    private string _connectionString = string.Empty;

    public CategoryQueries(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
    }


    public async Task<Category> GetCategoryAsync(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        return await connection.QueryFirstOrDefaultAsync<Category>("SELECT * FROM Categories  WHERE Id=@id", new { id });
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        return await connection.QueryAsync<Category>("SELECT * FROM Categories");
    }
}
