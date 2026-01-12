using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.UpdateObligator.DTOs;
public class UpdateObligatorDto
{
    public long Id { get; set; }
    public decimal? DebtAmount { get; set; }
    public string ContractNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public ICollection<ObligatorAssetsDto> ObligatorAssets { get; set; } = Enumerable.Empty<ObligatorAssetsDto>().ToList();
}
