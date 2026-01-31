using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Commands.UpdateEmployee.DTOs;
/// <summary>
///     Main DTO that encapsulates data for update.
/// </summary>
public class UpdateEnforcementEmployeeRequestDto
{
    public long Id { get; set; }
    public string? PassportNumber { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Login { get; set; }
    public string? Position { get; set; }

}
