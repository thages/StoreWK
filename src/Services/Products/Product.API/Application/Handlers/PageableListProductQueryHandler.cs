using Catalog.API.Application.Queries.Products;

namespace Catalog.API.Application.Handlers
{
    public class PageableListProductQueryHandler :
        IRequestHandler<ProductPageableListQuery, PageableResult<ProductPageableListItem>>
    {
        private readonly IProductQueries _productQueries;
        
        public PageableListProductQueryHandler(IProductQueries productQueries)
        {
            _productQueries = productQueries ?? throw new ArgumentNullException(nameof(_productQueries));
        }

        public async Task<PageableResult<ProductPageableListItem>> Handle(ProductPageableListQuery query, CancellationToken cancellationToken)
        {
            return await _productQueries.ProductsPageableList(query);
        }
    }
}
