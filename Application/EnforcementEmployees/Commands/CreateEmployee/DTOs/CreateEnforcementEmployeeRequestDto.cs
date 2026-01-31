using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Commands.CreateEmployee.DTOs;

/// <summary>
/// DTO representing an employee to be created in the system.
/// </summary>
public class CreateEnforcementEmployeeRequestDto
{
    public string PassportNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Position { get; set; }
    public long EnforcementEmployerId { get; set; }
}
