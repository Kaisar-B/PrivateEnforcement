using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Pagination;

public record Page<T>
{
    public Page(List<T> items, int count)
    {
        Items = items;
        Count = count;
    }

    public List<T> Items { get; init; }
    public int Count { get; init; }
}
