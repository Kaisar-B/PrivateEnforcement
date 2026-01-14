using Application.Administration.Queries.EnforcementList.DTOs;
using Application.Administration.Queries.Shared;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Enforcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Shared.Ordering;
using Microsoft.EntityFrameworkCore;

namespace Application.Administration.Queries.EnforcementList
{
    /// <summary>
    ///     Handles the retrieval of enforcement entities with optional filtering and sorting.
    /// </summary>
    /// <remarks>
    ///     Applies the filter and sort criteria specified in <see cref="EnforcementFilterSorting"/>.
    ///     Returns a list of <see cref="EnforcementDto"/> wrapped in a <see cref="Result{T}"/> object.
    /// </remarks>

    internal class EnforcementListCommand : IEnforcementList
    {
        private readonly DatabaseContext _dbContext;

        public EnforcementListCommand(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<EnforcementDto>>> QueryEnforcementListCommandAsync(EnforcementFilterSorting enforcementFilterSorting)
        {
            var enforcementAccounts = _dbContext.Enforcements;
            var query = ApplyFilter(enforcementAccounts, enforcementFilterSorting);
            query = ApplySorting(query, enforcementFilterSorting);

            var entities = await query.AsNoTracking().ToListAsync();
            if (entities.Any()) 
            {
                return Result<List<EnforcementDto>>.Ok(ApplyMappingToDto(entities.ToList()));
            }
            return Result<List<EnforcementDto>>.Fail("Не было найденно ни одной записи по данным параметрам");
        }

        private static IQueryable<EnforcementAccount> ApplyFilter(IQueryable<EnforcementAccount> enforcementAccounts, EnforcementFilterSorting dto)
        {
            if (dto.EnforcementId != null) 
            {
                enforcementAccounts = enforcementAccounts.Where(x=>x.Id == dto.EnforcementId);
            }
            if (dto.LicenseNumber != null) 
            {
                enforcementAccounts = enforcementAccounts.Where(x=>x.LicenseNumber == dto.LicenseNumber);
            }
            if (dto.City != null) 
            {
                enforcementAccounts = enforcementAccounts.Where(x=>x.City.Equals(dto.City));
            }
            if(dto.Country != null)
            {
                enforcementAccounts = enforcementAccounts.Where(x=>x.Country.Equals(dto.Country));
            }
            return enforcementAccounts;
        }

        private static IQueryable<EnforcementAccount> ApplySorting(IQueryable<EnforcementAccount> enforcementAccounts, EnforcementFilterSorting dto)
        {
            switch (dto.SortField) 
            {
                case (EnforcementSortEnum.ById):
                    enforcementAccounts = enforcementAccounts.Sort<EnforcementAccount, long>(x => x.Id, dto.SortByAscending);
                    return enforcementAccounts;
                case (EnforcementSortEnum.ByEnforcementName):
                    enforcementAccounts = enforcementAccounts.Sort<EnforcementAccount, string>(x => x.EnforcementName, dto.SortByAscending);
                    return enforcementAccounts;
                case (EnforcementSortEnum.ByLicenseNumber):
                    enforcementAccounts = enforcementAccounts.Sort<EnforcementAccount, string>(x=>x.LicenseNumber, dto.SortByAscending);
                    return enforcementAccounts ;
                case (EnforcementSortEnum.ByCity):
                    enforcementAccounts = enforcementAccounts.Sort<EnforcementAccount, string>(x=>x.City, dto.SortByAscending);
                    return enforcementAccounts;
                case (EnforcementSortEnum.ByCountry):
                    enforcementAccounts = enforcementAccounts.Sort<EnforcementAccount, string>(x=>x.Country, dto.SortByAscending);
                    return enforcementAccounts;
            }
            return enforcementAccounts;
        }

        public static List<EnforcementDto> ApplyMappingToDto(List<EnforcementAccount> enforcementAccounts)
        {
            return enforcementAccounts.Select(x => new EnforcementDto() { EnforcementName = x.EnforcementName, LicenseNumber = x.LicenseNumber, City = x.City, Country = x.Country }).ToList();
        }
    }
}
