using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Queries.ObligatorsList.DTOs;
public record ObligatorsListDto
{
    public long ObligatorId { get; set; }
    public DateTime CreationDateTime { get; set; }
    public bool IsDeleted { get; set; }
    public decimal? DebtAmount {  get; set; }
    public string ContractNumber { get; set; }
    public ICollection<ObligatorAssetsModel> Assets {  get; set; }
}
