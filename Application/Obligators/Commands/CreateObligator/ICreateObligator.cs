using Application.Obligators.Commands.CreateObligator.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.CreateObligator;

/// <summary>
///     Interface for creating new obligator
/// </summary>
public interface ICreateObligator
{
    public Task<Result<int>> CreateObligatorAsync(CreateObligatorRequestDto newObligator);
}
