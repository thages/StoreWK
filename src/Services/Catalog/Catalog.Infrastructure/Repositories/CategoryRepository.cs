namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CatalogContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public CategoryRepository(CatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Category Add(Category category)
    {
        return _context.Categories.Add(category).Entity;

    }

    public async Task<Category> GetAsync(int categoryId)
    {
        var category = await _context
                            .Categories
                            .FirstOrDefaultAsync(o => o.Id == categoryId);
        if (category == null)
        {
            category = _context
                        .Categories
                        .Local
                        .FirstOrDefault(o => o.Id == categoryId);
        }

        return category;
    }

    public Category Update(Category category)
    {
       return _context.Update(category).Entity;
    }

    public void Remove(Category category)
    {
        _context.Categories.Remove(category);
    }

}
