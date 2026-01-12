using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Queries.EmployeesList.Shared;
public class EmployeeFilterSort
{

    // Filters
    public DateTime? FromCreationDateTime { get; set; }
    public DateTime? BeforeCreationDateTime { get; set; }

    // Sorting
    public SortEmployeeEnum SortField { get; set; } = SortEmployeeEnum.ById;
    public bool SortByAscending { get; set; } = false;

    // Paging
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
