using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.CreateObligator.DTOs;
public class NewObligatorDto
{
    public decimal DebtAmount { get; set; }
    public string ObligationContractNumber { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public long OwnerEnforcementAccountId { get; set; }
    public ICollection<ObligatorAssetsDto> ObligatorAssets { get; set; }
}
