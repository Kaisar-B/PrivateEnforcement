using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.CreateObligator.DTOs;

/// <summary>
///     DTO for obligator assets representation
/// </summary>
public class ObligatorAssetsDto
{
    /// <summary>
    ///     Asset estimated market value
    /// </summary>
    public decimal AssetValue { get; set; }

    /// <summary>
    ///     Name of assets (brand, mark)
    /// </summary>
    public string AssetName { get; set; }

    /// <summary>
    ///     Description of asset
    /// </summary>
    public string DescriptionOfAsset { get; set; } = string.Empty;

}
