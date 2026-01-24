using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Queries.DTOs;
/// <summary>
///     DTO that represents obligator assets.
/// </summary>
public class ObligatorAssetDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal AssetsValue { get; set; }
}
