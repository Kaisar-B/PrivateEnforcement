using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Queries.ObligatorsList.DTOs;
public record ObligatorAssetsModel
{
    public string AssetName { get; set; }
    public decimal AssetValue { get; set; }
    public string AssetDescription { get; set; }
}
