namespace Catalog.Infrastructure.Repositories;

public class ProductRepository
    : IProductRepository
{
    private readonly CatalogContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ProductRepository(CatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Product Add(Product product)
    {
        return _context.Products.Add(product).Entity;

    }

    public async Task<Product> GetAsync(int productId)
    {
        var product = await _context
                            .Products
                            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null)
        {
            product = _context
                        .Products
                        .Local
                        .FirstOrDefault(p => p.Id == productId);
        }
        
        return product;
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        var product = await _context
                           .Products
                           .SingleOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public Product Update(Product product)
    {
        return _context.Update(product).Entity;
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }
}
