namespace Catalog.Domain.AggregatesModel.Common;

public class PageableResult<TResult>
{
    public int PageSize { get; }
    public int CurrentPage { get; }
    public List<TResult> Results { get; }
    
    public PageableResult(int pageSize, int currentPage, List<TResult> results)
    {
        PageSize = pageSize;
        CurrentPage = currentPage;
        Results = results ?? throw new ArgumentNullException(nameof(results));
    }
}
