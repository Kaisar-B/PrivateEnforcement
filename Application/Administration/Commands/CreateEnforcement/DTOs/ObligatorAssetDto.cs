using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.DTOs;

/// <summary>
///     DTO that contains information about private enforcement`s direct client` (his obligators) assets.
///     This DTO contains information about assets of obligator. 
///     Works as part of obligator DTO.
/// </summary>
public class ObligatorAssetDto
{
    public decimal AssetValue { get; set; }
    public string AssetName { get; set; }
    public string DescriptionOfAsset { get; set; }
}
