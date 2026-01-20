using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Queries.EmployeesList.DTOs;

/// <summary>
/// 
/// </summary>
public class EnforcementEmployeeDto
{
    public long Id {  get; set; }
    public DateTime CreatedDate { get; set; }
    public string PassportNumber { get; set; }
    public string FullName { get; set; }
    public string Login {  get; set; }
    public bool IsBlocked { get; set; }
    public long EnforcementEmployerId { get; set; }
    public string Position { get; set; }
}
