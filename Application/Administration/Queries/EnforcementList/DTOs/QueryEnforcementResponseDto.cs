using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Queries.EnforcementList.DTOs
{
    /// <summary>
    ///     Main DTO that that encapsulates data retrived
    /// </summary>
    public class QueryEnforcementResponseDto
    {
        public string? EnforcementName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
