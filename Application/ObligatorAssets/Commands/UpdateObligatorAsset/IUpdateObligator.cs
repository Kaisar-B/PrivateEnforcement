using Application.Obligators.Commands.UpdateObligator.DTOs;
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
public interface IUpdateObligator
{
    public Task<Result<string>> UpdateObligatorAssetCommand(ObligatorAssetsDto dto);
}
