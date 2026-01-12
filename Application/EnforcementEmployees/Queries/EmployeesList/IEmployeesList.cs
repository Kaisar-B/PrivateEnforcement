using Application.EnforcementEmployees.Queries.EmployeesList.Shared;
using Application.Shared.Results;
using Domain.Entities.Account.Enforcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Queries.EmployeesList;
public interface IEmployeesList
{
    public Task<Result<List<EnforcementEmployee>>> GetEmployeesListAsync(EmployeeFilterSort employeeFilterSort);
}
