using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.CreateObligator.DTOs;
public class ObligatorAssetsDto
{
    /// <summary>
    ///     Стоимость актива
    /// </summary>
    public decimal AssetValue { get; set; }

    /// <summary>
    ///     Имя актива
    /// </summary>
    public string AssetName { get; set; }

    /// <summary>
    ///     Описание актива
    /// </summary>
    public string DescriptionOfAsset { get; set; } = string.Empty;
}
