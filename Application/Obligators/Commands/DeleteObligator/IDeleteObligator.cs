using Application.Obligators.Commands.DeleteObligator.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.DeleteObligator;

/// <summary>
///     Interface for deleting obligators based on id and other complex unique identifier.
/// </summary>
public interface IDeleteObligator
{
    public Task<Result<int>> DeleteObligatorByIdAsync(long id);
    public Task<Result<int>> DeleteObligatorAsync(DeleteObligatorDto dto);
}
