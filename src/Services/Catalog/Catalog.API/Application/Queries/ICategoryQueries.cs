namespace Catalog.API.Application.Queries
{
    public interface ICategoryQueries
    {
        Task<Category> GetCategoryAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
