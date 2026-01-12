using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.DTOs;
public class EnforcementEmployeeDto
{
    public string PassportNumber { get; set; }
    public string Name { get; set; }
    public string Surname {  get; set; }
    public string Login {  get; set; }
    public string Password {  get; set; }
    public string Position { get; set; }
}
