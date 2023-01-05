namespace Catalog.Domain.AggregatesModel.CategoryAggregate;

public interface ICategoryRepository : IRepository<Category>
{
    Category Add(Category category);

    Category Update(Category category);

    Task<Category> GetAsync(int categoryId);

    void Remove(Category category);
}
