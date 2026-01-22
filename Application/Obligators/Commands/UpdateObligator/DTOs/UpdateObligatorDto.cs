using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.UpdateObligator.DTOs;

/// <summary>
///     DTO model for updating obligator info and his owning assets.
/// </summary>
public class UpdateObligatorDto
{
    /// <summary>
    ///     Id of obligator
    /// </summary>
    public long Id { get; set; }
    public decimal? DebtAmount { get; set; }
    public string ContractNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public ICollection<ObligatorAssetsDto> ObligatorAssets { get; set; } = Enumerable.Empty<ObligatorAssetsDto>().ToList();
}
