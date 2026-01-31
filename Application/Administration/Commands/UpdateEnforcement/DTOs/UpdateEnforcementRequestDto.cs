using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.DTOs;

/// <summary>
///  Main DTO that that encapsulates update data of enforcement
/// </summary>
public class UpdateEnforcementRequestDto
{
    public long EnforcementId { get; set; }
    public string? EnforcementName { get; set; }
    public string? LicenseNumber { get; set; }
    public string? City {  get; set; }
    public string? Country { get; set; }
}
