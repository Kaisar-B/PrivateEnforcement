using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Queries.Shared;
public class ObligatorFilterSorting
{
    public long OwningEnforcementId { get; set; }
    // Filters
    public decimal? MinDebAmount { get; set; }
    public decimal? MaxDebtAmount { get; set; }
    public string? Region { get; set; }
    public string? City { get; set; }
    public bool? IsActive { get; set; }

    // Sorting
    public SortObligatorEnum SortField { get; set; } = SortObligatorEnum.ByName;
    public bool SortByAscending { get; set; } = false;

    // Paging
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
