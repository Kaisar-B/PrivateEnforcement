using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.DeleteObligator.DTOs;
public class DeleteObligatorDto
{
    public long? Id { get; set; }
    public string PassportNumber { get; set; }
    public string ContractNumber { get; set; }
}
