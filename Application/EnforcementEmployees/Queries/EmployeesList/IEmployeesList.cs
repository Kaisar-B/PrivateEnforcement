using Application.EnforcementEmployees.Queries.EmployeesList.Shared;
using Application.Shared.Results;
using Domain.Entities.Account.Enforcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EnforcementEmployees.Queries.EmployeesList.DTOs;

namespace Application.EnforcementEmployees.Queries.EmployeesList;

/// <summary>
///     Service interface for querying list of emplyees of private enforcement
/// </summary>
public interface IEmployeesList
{
    /// <summary>
    ///     Retrives one or many enforcement employees
    /// </summary>
    /// <param name="employeeFilterSort"></param>
    /// <returns>List of employees, or fail with message</returns>
    public Task<Result<List<EnforcementEmployeeDto>>> GetEmployeesListAsync(EmployeeFilterSort employeeFilterSort);
}
