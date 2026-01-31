using Application.ObligatorAssets.Commands.CreateObligatorAsset.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.CreateObligatorAsset;

/// <summary>
///     Interface for creating new obligator asset record, binded for specific obligator
/// </summary>
public interface ICreateObligatorAsset
{
    public Task<Result<Unit>> CreateNewObligatorAssetCommandAsync(List<CreateObligatorAssetRequestDto> dto);
}
