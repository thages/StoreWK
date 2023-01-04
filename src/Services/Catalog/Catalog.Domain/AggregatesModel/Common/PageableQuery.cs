namespace Catalog.Domain.AggregatesModel.Common;

public class PageableQuery<TOrderBy> : Pageable where TOrderBy : Enum
{
    public TOrderBy OrderBy { get; set; }
}
