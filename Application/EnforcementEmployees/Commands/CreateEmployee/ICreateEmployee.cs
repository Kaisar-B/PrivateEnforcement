using Application.Employees.Commands.CreateEmployee.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Commands.CreateEmployee;
public interface ICreateEmployee
{
    public Task<Result<string>> CreateEmployeesAsync(List<CreateEmployeeDto> dto);
}
