using Application.EnforcementEmployees.Commands.UpdateEmployee.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Commands.UpdateEmployee;
public interface IUpdateEmployee
{
    public Task<Result<string>> UpdateEmployeesAsync(List<UpdateEmployeeDto> dtos);
}
