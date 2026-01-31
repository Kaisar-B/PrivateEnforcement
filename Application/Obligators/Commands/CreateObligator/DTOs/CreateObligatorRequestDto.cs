using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.CreateObligator.DTOs;

/// <summary>
///     DTO for creating new obligator
/// </summary>
public class CreateObligatorRequestDto
{
    /// <summary>
    ///     Name of obligator
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Surname of obligator.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    ///     Passport number of obligator.
    /// </summary>
    public string PassportNumber { get; set; }

    /// <summary>
    ///     Debt amount of obligator
    /// </summary>
    public decimal DebtAmount { get; set; }
    /// <summary>
    ///     Contract or paper number, where obligator signed or etc.
    /// </summary>
    public string ObligationContractNumber { get; set; }
    /// <summary>
    ///     City where obligator lives.
    /// </summary>
    public string City { get; set; }
    /// <summary>
    ///     Region where obligator lives.
    /// </summary>
    public string Region { get; set; }
    /// <summary>
    ///     Id of owner private enforcement (who owns current obligator)
    /// </summary>
    public long OwnerEnforcementAccountId { get; set; }
    public ICollection<ObligatorAssetsDto> ObligatorAssets { get; set; }
}
