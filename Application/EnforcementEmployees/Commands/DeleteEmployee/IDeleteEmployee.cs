using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Commands.DeleteEmployee;
public interface IDeleteEmployee
{
    public Task<Result<string>> DeleteEmployeesByIdAsync(List<long> Ids);
}
