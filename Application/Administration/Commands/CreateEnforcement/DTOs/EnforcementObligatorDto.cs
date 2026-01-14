using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.DTOs;

/// <summary>
///     DTO that contains information about private enforcement`s direct client (his obligators).
///     Works as part of main DTO.
/// </summary>
public class EnforcementObligatorDto
{
    public string PassportNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal DebtAmount { get; set; }
    public string ObligationContractNumber { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public ICollection<ObligatorAssetDto> ObligatorAssetDtos { get; set; }
}
