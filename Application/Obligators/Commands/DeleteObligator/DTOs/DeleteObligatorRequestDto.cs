using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.DeleteObligator.DTOs;

/// <summary>
///     DTO model that contains unique (alternative keys) that allows 
///     uniquely identify row in DB and delete it.
/// </summary>
public class DeleteObligatorRequestDto
{
    public long? Id { get; set; }
    public string? PassportNumber { get; set; }
    public string? ContractNumber { get; set; }
}
