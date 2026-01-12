using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Pagination;
public record Pagination
{
    public Pagination(int page, int pageSize)
    {
        PageIndex = page - 1;
        PageSize = pageSize;
    }

    public int PageIndex { get; init; }
    public int PageSize { get; init; }
}
