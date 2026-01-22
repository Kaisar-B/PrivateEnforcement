using Application.Obligators.Commands.UpdateObligator.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.UpdateObligator;

/// <summary>
///     Interface for updating data related to Obligator
/// </summary>
public interface IUpdateObligator
{
    public Task<Result<int>> UpdateObligatorAsync(UpdateObligatorDto updateObligatorDto);
}
