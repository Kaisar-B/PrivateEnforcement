using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Commands.CreateEmployee.DTOs;

/// <summary>
/// DTO representing an employee to be created in the system.
/// </summary>
public class CreateEmployeeDto
{
    public string PassportNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Login { get; set; }
    public string Position { get; set; }
}
