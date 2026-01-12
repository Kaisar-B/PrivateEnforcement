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

namespace Application.EnforcementEmployees.Queries.EmployeesList;
internal class EmployeeListCommand : IEmployeesList
{
    private readonly DatabaseContext _dbContext;

    public EmployeeListCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<List<EnforcementEmployee>>> GetEmployeesListAsync(EmployeeFilterSort employeeFilterSort)
    {
        var domainModels = _dbContext.EnforcementEmployees;
        var sortedQuery = BuildSorting(employeeFilterSort, domainModels);
        var filteredQuery = BuildFilter(employeeFilterSort, sortedQuery);

        try
        {
            var result = await filteredQuery.ToListAsync();
            //todo convert domain model to DTO
            return new Result<List<EnforcementEmployee>>()
            {
                IsSuccess = true,
                ResponseMessage = "Запрос успешно обработон",
                ResultData = result
            };
        }
        catch (Exception ex) 
        {
            return new Result<List<EnforcementEmployee>>()
            {
                IsSuccess = false,
                ResponseMessage = ex.Message,
            };
        }
    }

    private IQueryable<EnforcementEmployee> BuildSorting(EmployeeFilterSort filterSort, IQueryable<EnforcementEmployee> queryable)
    {
        if(filterSort.SortField == SortEmployeeEnum.ByName)
        {
            if (filterSort.SortByAscending)
            {
                queryable = queryable.OrderBy(x => x.Name);
                return queryable;
            }
            queryable = queryable.OrderByDescending(x => x.Name);
            return queryable;
        }
        if(filterSort.SortField == SortEmployeeEnum.BySurname)
        {
            if (filterSort.SortByAscending)
            {
                queryable = queryable.OrderBy(x => x.Surname);
                return queryable;
            }
            queryable = queryable.OrderByDescending(x => x.Surname);
            return queryable;
        }
        if(filterSort.SortField == SortEmployeeEnum.ByPassportNumber)
        {
            if (filterSort.SortByAscending)
            {
                queryable = queryable.OrderBy(x => x.PassportNumber);
                return queryable;
            }
            queryable = queryable.OrderByDescending(x => x.PassportNumber);
            return queryable;
        }
        if (filterSort.SortField == SortEmployeeEnum.ByDateTime)
        {
            if (filterSort.SortByAscending)
            {
                queryable = queryable.OrderBy(x => x.CreationDateTime);
                return queryable;
            }
            queryable = queryable.OrderByDescending(x => x.CreationDateTime);
            return queryable;
        }
        if (filterSort.SortField == SortEmployeeEnum.ById)
        {
            if (filterSort.SortByAscending)
            {
                queryable = queryable.OrderBy(x => x.Id);
                return queryable;
            }
            queryable = queryable.OrderByDescending(x => x.Id);
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
