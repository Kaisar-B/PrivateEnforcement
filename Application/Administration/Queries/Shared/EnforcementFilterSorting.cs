using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Queries.Shared
{
    /// <summary>
    ///     Combination of Filtering and Sorting for Enforcement domain only.
    /// </summary>
    public class EnforcementFilterSorting
    {
        public long? EnforcementId { get; set; }
        public string? LicenseNumber { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool SortByAscending { get; set; }
        public EnforcementSortEnum SortField { get; set; }
    }
}
