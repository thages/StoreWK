namespace Catalog.Domain.AggregatesModel.ProductAggregate;

public interface IProductRepository : IRepository<Product>
{
    Product Add(Product product);

    Product Update(Product product);

    Task<Product> GetAsync(int productId);

    void Remove(Product product);

    Task<Product> FindByIdAsync(int id);
}
