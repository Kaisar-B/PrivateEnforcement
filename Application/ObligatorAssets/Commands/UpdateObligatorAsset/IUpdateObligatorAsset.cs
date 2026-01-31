using Application.ObligatorAssets.Commands.UpdateObligatorAsset.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.UpdateObligatorAsset;
/// <summary>
///     Interface for updating obligator assets record.
/// </summary>
public interface IUpdateObligatorAsset
{
    public Task<Result<string>> UpdateObligatorAssetCommand(UpdateObligatorAssetRequestDto dto);
}
