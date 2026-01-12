using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Pagination;
public static class PaginationExtension
{
    public async static Task<Page<T>> ToPageAsync<T>(this IQueryable<T> source, Pagination pagination)
    {
        var result = await source.Skip(pagination.PageIndex*pagination.PageIndex).Take(pagination.PageSize).ToListAsync();

        return new Page<T>(result, result.Count);
    }
}
