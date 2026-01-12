using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Queries.ObligatorDetailedQuery.ObligatorAssets.DTOs;
public class AssetDetailedDto
{
    public long Id { get; set; }
    public string AssetName { get; set; }
    public decimal AssetValue { get; set; }
    public DateTime CreationDateTime { get; set; }
    public string AssetDescription { get; set; }
    public long OwnerObligator { get; set; }

}
