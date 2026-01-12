using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Ordering;
public static class OrderingExtension
{
    public static IQueryable<T> Sort<T, TProperty>(this IQueryable<T> list, Expression<Func<T, TProperty>> selector, bool ascending)
    {
        return ascending ? list.OrderBy(selector) : list.OrderByDescending(selector);
    }
}
