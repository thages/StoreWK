using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.AggregatesModel.Common
{
    public class Pageable
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int Skip => (CurrentPage - 1) * PageSize;
    }
}
