using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.DTOs;
public class EnforcementDto
{
    public string EnforcementName { get; set; }
    public string LicenseNumber { get; set; }
    public string City {  get; set; }
    public string Country { get; set; }
    public ICollection<EnforcementEmployeeDto> EnforcementEmployeesDto { get; set; }
    public ICollection<EnforcementObligatorDto> EnforcementObligatorsDto { get; set; }
}
