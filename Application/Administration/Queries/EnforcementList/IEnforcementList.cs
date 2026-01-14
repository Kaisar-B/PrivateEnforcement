using Application.Administration.Queries.EnforcementList.DTOs;
using Application.Administration.Queries.Shared;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Queries.EnforcementList
{
    public interface IEnforcementList
    {
        /// <summary>
        ///     Queries the list of enforcements with optional filtering and sorting.
        /// </summary>
        /// <param name="enforcementFilterSorting">Filter and sorting options.</param>
        /// <returns>Result containing a list of <see cref="EnforcementDto"/> or failure message.</returns>
        public Task<Result<List<EnforcementDto>>> QueryEnforcementListCommandAsync(EnforcementFilterSorting enforcementFilterSorting);
    }

}
