using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.UpdateObligator.DTOs;
public class ObligatorAssetsDto
{
    public long Id { get; set; }
    /// <summary>
    ///     Стоимость актива
    /// </summary>
    public decimal? AssetValue { get; set; }

    /// <summary>
    ///     Имя актива
    /// </summary>
    public string? AssetName { get; set; } = string.Empty;

    /// <summary>
    ///     Описание актива
    /// </summary>
    public string? DescriptionOfAsset { get; set; } = string.Empty;
}

