using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Queries.ObligatorDetailedQuery.Shared;
public class ObligatorDetailedQueryResult<TResult>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public TResult Result { get; set; }
}
