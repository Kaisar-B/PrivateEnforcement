using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.DTOs;
public class ObligatorAssetDto
{
    public decimal AssetValue { get; set; }
    public string AssetName { get; set; }
    public string DescriptionOfAsset { get; set; }
}
