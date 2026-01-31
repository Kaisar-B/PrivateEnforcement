using Application.Employees.Commands.CreateEmployee.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Commands.CreateEmployee;

/// <summary>
///     Service interface for creating employees in the Enforcement domain.
/// </summary>
public interface ICreateEmployee
{
    /// <summary>
    ///     Creates one or more employees in the database.
    /// </summary>
    /// <param name="dto">List of employee DTOs to create.</param>
    /// <returns>Result indicating success or failure.</returns>
    public Task<Result<string>> CreateEmployeesAsync(List<CreateEnforcementEmployeeRequestDto> dto);
}
