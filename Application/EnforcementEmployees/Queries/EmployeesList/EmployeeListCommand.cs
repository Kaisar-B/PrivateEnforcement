using Application.EnforcementEmployees.Queries.EmployeesList.Shared;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Enforcement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EnforcementEmployees.Queries.EmployeesList.DTOs;
using Application.Shared.Ordering;

namespace Application.EnforcementEmployees.Queries.EmployeesList;

/// <summary>
///     Provides functionality for retrieving a filtered and sorted list of enforcement employees.
/// </summary>
/// <remarks>
/// This class builds an Entity Framework query by applying filtering, sorting,
/// and projection to DTOs before executing the query asynchronously.
/// </remarks>
internal class EmployeeListCommand : IEmployeesList
{
    private readonly DatabaseContext _dbContext;

    public EmployeeListCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<List<EnforcementEmployeeDto>>> GetEmployeesListAsync(EmployeeFilterSort employeeFilterSort)
    {
        var domainModels = _dbContext.EnforcementEmployees;
        var filteredQuery = BuildFilter(employeeFilterSort, domainModels);
        var sortedQuery = BuildSorting(employeeFilterSort, filteredQuery);
        

        try
        {
            var dtoModel = sortedQuery.Select(x => new EnforcementEmployeeDto() { Id = x.Id, CreatedDate = x.CreationDateTime, PassportNumber = x.PassportNumber, FullName = string.Concat(x.Surname, " ", x.Name), EnforcementEmployerId = x.EnforcementEmployerId, IsBlocked = x.IsBlocked, Login = x.Login });
            var result = await dtoModel.ToListAsync();
            return Result<List<EnforcementEmployeeDto>>.Ok(result);
        }
        catch (Exception ex) 
        {
            return Result<List<EnforcementEmployeeDto>>.Fail(ex.Message);
        }
    }

    private IQueryable<EnforcementEmployee> BuildSorting(EmployeeFilterSort filterSort, IQueryable<EnforcementEmployee> queryable)
    {
        if(filterSort.SortField == SortEmployeeEnum.ByName)
        {
            queryable = queryable.Sort<EnforcementEmployee, string>(x=>x.Name, filterSort.SortByAscending);
            return queryable;
        }
        if(filterSort.SortField == SortEmployeeEnum.BySurname)
        {
            queryable = queryable.Sort<EnforcementEmployee, string>(x => x.Surname, filterSort.SortByAscending);
            return queryable;
        }
        if(filterSort.SortField == SortEmployeeEnum.ByPassportNumber)
        {
            queryable = queryable.Sort<EnforcementEmployee, string>(x=>x.PassportNumber, filterSort.SortByAscending);
            return queryable;
        }
        if (filterSort.SortField == SortEmployeeEnum.ByDateTime)
        {
            queryable = queryable.Sort<EnforcementEmployee, DateTime>(x => x.CreationDateTime, filterSort.SortByAscending);
            return queryable;
        }
        if (filterSort.SortField == SortEmployeeEnum.ById)
        {
            queryable = queryable.Sort<EnforcementEmployee, long>(x => x.Id, filterSort.SortByAscending);
            return queryable;
        }
        return queryable;
    }

    private IQueryable<EnforcementEmployee> BuildFilter(EmployeeFilterSort employeeFilterSort, IQueryable<EnforcementEmployee> queryable)
    {
        if (employeeFilterSort.FromCreationDateTime != null)
        {
            queryable = queryable.Where(x=>x.CreationDateTime>=employeeFilterSort.FromCreationDateTime);
        }
        if(employeeFilterSort.BeforeCreationDateTime != null)
        {
            queryable = queryable.Where(x=>x.CreationDateTime <= employeeFilterSort.BeforeCreationDateTime);
        }
        return queryable;
    }
}
